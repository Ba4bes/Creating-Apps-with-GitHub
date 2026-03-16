using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors();

var dataFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "data", "experiments.json");

List<Dictionary<string, object>> ReadExperiments()
{
    var json = File.ReadAllText(dataFile);
    return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json)!;
}

void WriteExperiments(List<Dictionary<string, object>> data)
{
    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(dataFile, json);
}

// Serve the frontend as static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "frontend")),
    RequestPath = ""
});

// GET /entries — return all log entries
app.MapGet("/entries", () =>
{
    var experiments = ReadExperiments();
    return Results.Ok(experiments);
});

// GET /entries/{id} — return one entry by id
app.MapGet("/entries/{id}", (string id) =>
{
    var experiments = ReadExperiments();
    var entry = experiments.FirstOrDefault(e =>
        e.TryGetValue("id", out var val) && val.ToString() == id);
    return entry is null
        ? Results.NotFound(new { error = "Entry not found" })
        : Results.Ok(entry);
});

// POST /entries — add a new entry
app.MapPost("/entries", async (HttpRequest request) =>
{
    var body = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(request.Body);
    if (body is null) return Results.BadRequest(new { error = "Invalid request body" });

    string[] required = ["tool", "task", "expected", "actual", "verdict"];
    if (!required.All(f => body.ContainsKey(f) && !string.IsNullOrWhiteSpace(body[f])))
    {
        return Results.BadRequest(new { error = "All fields are required: tool, task, expected, actual, verdict" });
    }

    var experiments = ReadExperiments();
    var newEntry = new Dictionary<string, object>
    {
        ["id"] = $"exp-{Guid.NewGuid().ToString("N")[..8]}",
        ["tool"] = body["tool"],
        ["task"] = body["task"],
        ["expected"] = body["expected"],
        ["actual"] = body["actual"],
        ["verdict"] = body["verdict"],
        ["timestamp"] = DateTime.UtcNow.ToString("o")
    };
    experiments.Add(newEntry);
    WriteExperiments(experiments);
    return Results.Created($"/entries/{newEntry["id"]}", newEntry);
});

// GET /summary — aggregated experiment data
// TODO: Implement this endpoint in Lab 2
// The endpoint should return a JSON object with this shape:
// {
//   "total": <number of entries>,
//   "by_verdict": {
//     "Faster": <count>,
//     "Same": <count>,
//     "Slower": <count>,
//     "Surprising": <count>
//   },
//   "by_tool": {
//     "<tool name>": {
//       "Faster": <count>,
//       "Same": <count>,
//       "Slower": <count>,
//       "Surprising": <count>
//     }
//   }
// }
app.MapGet("/summary", () =>
{
    return Results.Json(new { error = "Not implemented — build this in Lab 2!" }, statusCode: 501);
});

app.Run("http://localhost:5001");

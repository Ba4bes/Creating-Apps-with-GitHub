# Lab 2 — Core Guided: Implement the Summary Endpoint

**Goal:** Use Copilot inline completion to implement the `GET /summary` endpoint, unlocking the dashboard charts.

**Time:** 35 minutes

**You will need:** Lab 1 completed, Copilot instructions file in place, API running in your Codespace.

---

## Background

Your API already has endpoints for listing and adding experiment entries (`GET /entries`, `POST /entries`). The frontend has a **Dashboard** view that tries to call `GET /summary` to display charts, but that endpoint currently returns a `501 Not Implemented` response. In this lab you will:

1. Add a few experiment entries so the dashboard has data to show
2. Find the 501 stub in your API file
3. Use Copilot inline completion to implement the aggregation logic
4. Verify the dashboard charts appear
5. Commit your changes

The endpoint must return a JSON object that groups experiments by verdict and by tool. The frontend reads this to render a doughnut chart (verdict breakdown) and a stacked bar chart (tool comparison).

---

## Steps

### Part A: Add Test Data

1. Start your API server if it is not already running:

   - **Node:**
     ```bash
     cd node
     npm start
     ```

   - **Python:**
     ```bash
     cd python
     pip install -r requirements.txt
     python app.py
     ```

   - **.NET:**
     ```bash
     cd dotnet
     dotnet run
     ```

2. Open the app in your browser. In a Codespace, click the **Ports** tab and open the forwarded port (3000 for Node, 5000 for Python, 5001 for .NET).

3. Click the **Add Entry** tab and add 3–4 experiments with **different tools and verdicts**. For example:

   | Tool | Task | Expected | Actual | Verdict |
   |------|------|----------|--------|---------|
   | Codespaces | Set up dev environment | Quick setup | Ready in 30 seconds | Faster |
   | Copilot config files | Create instructions file | Copilot follows style | It matched my preferences | Faster |
   | Codespaces | Install extension | One click install | Had to reload twice | Same |
   | Copilot config files | Security review skill | Thorough review | Missed one category | Surprising |

   > **Why add entries now?** The charts are more interesting with varied data. If you implement the endpoint with an empty dataset, everything will show zero.

4. Switch to the **Dashboard** tab. You should see the message: *"Summary not yet available — implement the `/summary` endpoint in Lab 2 to unlock the dashboard charts."* This confirms the 501 stub is active.

5. Stop the API server (press `Ctrl+C` in the terminal) so you can edit the file.

### Part B: Find the `/summary` Stub

6. Open your API file in the editor:
   - **Node:** `node/server.js`
   - **Python:** `python/app.py`
   - **.NET:** `dotnet/Program.cs`

7. Find the `/summary` endpoint. Look for the block comment that describes the expected JSON shape and the `501` status code. Here is what it looks like in each language:

   **Node** (at the bottom of `server.js`):
   ```javascript
   // GET /summary — aggregated experiment data
   // TODO: Implement this endpoint in Lab 2
   // The endpoint should return a JSON object with this shape:
   // {
   //   "total": <number of entries>,
   //   "by_verdict": { ... },
   //   "by_tool": { ... }
   // }
   app.get("/summary", (req, res) => {
     res.status(501).json({ error: "Not implemented — build this in Lab 2!" });
   });
   ```

   **Python** (at the bottom of `app.py`):
   ```python
   @app.route("/summary", methods=["GET"])
   def get_summary():
       """Aggregated experiment data.
       TODO: Implement this endpoint in Lab 2.
       ...
       """
       return jsonify({"error": "Not implemented — build this in Lab 2!"}), 501
   ```

   **.NET** (at the bottom of `Program.cs`):
   ```csharp
   app.MapGet("/summary", () =>
   {
       return Results.Json(new { error = "Not implemented — build this in Lab 2!" }, statusCode: 501);
   });
   ```

8. Read the comment carefully. The expected JSON response looks like:

   ```json
   {
     "total": 6,
     "by_verdict": {
       "Faster": 3,
       "Same": 1,
       "Slower": 1,
       "Surprising": 1
     },
     "by_tool": {
       "Copilot Inline": {
         "Faster": 2,
         "Same": 1,
         "Slower": 0,
         "Surprising": 0
       },
       "Copilot Chat": {
         "Faster": 1,
         "Same": 0,
         "Slower": 1,
         "Surprising": 1
       }
     }
   }
   ```

   Key things to understand about the shape:
   - **`total`** — the total number of experiment entries
   - **`by_verdict`** — a flat object counting how many entries have each verdict value (`Faster`, `Same`, `Slower`, `Surprising`)
   - **`by_tool`** — a nested object where each key is a tool name, and the value is the verdict breakdown for *that specific tool*

### Part C: Implement Using Copilot Inline Completion

9. Delete the line that returns the 501 response:

   - **Node:** Delete `res.status(501).json({ error: "Not implemented — build this in Lab 2!" });`
   - **Python:** Delete `return jsonify({"error": "Not implemented — build this in Lab 2!"}), 501`
   - **.NET:** Delete `return Results.Json(new { error = "Not implemented — build this in Lab 2!" }, statusCode: 501);`

10. Inside the now-empty handler function, write a descriptive comment that tells Copilot what you want. This is the "prompt" for inline completion. For example:

    - **Node:**
      ```javascript
      // Read all experiments and aggregate counts by verdict and by tool
      ```

    - **Python:**
      ```python
      # Read all experiments and aggregate counts by verdict and by tool
      ```

    - **.NET:**
      ```csharp
      // Read all experiments and aggregate counts by verdict and by tool
      ```

11. Press **Enter** at the end of the comment line. Copilot should show a grey inline suggestion. Wait a moment for it to appear.

    > **What to look for:** Copilot should suggest code that:
    > 1. Reads the experiments (using the `readExperiments()` / `read_experiments()` / `ReadExperiments()` helper that already exists in the file)
    > 2. Initializes a `by_verdict` object with zero counts for each verdict
    > 3. Initializes a `by_tool` object
    > 4. Loops through all experiments, incrementing the counts
    > 5. Returns the result as JSON

12. Press **Tab** to accept the suggestion. If it only gives you part of the implementation, press **Enter** again and accept the next suggestion. Repeat until the implementation is complete.

13. If Copilot's suggestion doesn't look right, try these approaches:
    - **Be more specific in the comment:** e.g., `// Loop through experiments, count each verdict, and group by tool name with verdict breakdown`
    - **Start writing the first line of code yourself:** e.g., type `const experiments = readExperiments();` and then let Copilot continue from there
    - **Use Copilot Chat:** Open the chat panel and ask `Implement the /summary endpoint in server.js based on the TODO comment`

14. Review the generated code. Make sure it:
    - Calls the existing read function to get the experiments array
    - Returns a JSON object with `total`, `by_verdict`, and `by_tool` keys
    - Handles the case where a tool appears for the first time (initializes the verdict counts for new tools)
    - Returns a 200 status code (which is the default)

### Part D: Test the Endpoint

15. Save the file and restart the API server:

    - **Node:** `npm start`
    - **Python:** `python app.py`
    - **.NET:** `dotnet run`

16. Test the endpoint directly in a new terminal to verify the JSON shape:

    ```bash
    curl http://localhost:3000/summary   # Node
    curl http://localhost:5000/summary   # Python
    curl http://localhost:5001/summary   # .NET
    ```

    You should see JSON output similar to:
    ```json
    {
      "total": 4,
      "by_verdict": {
        "Faster": 2,
        "Same": 1,
        "Slower": 0,
        "Surprising": 1
      },
      "by_tool": {
        "Codespaces": {
          "Faster": 1,
          "Same": 1,
          "Slower": 0,
          "Surprising": 0
        },
        "Copilot config files": {
          "Faster": 1,
          "Same": 0,
          "Slower": 0,
          "Surprising": 1
        }
      }
    }
    ```

    > **Check:** Does the response have all three keys (`total`, `by_verdict`, `by_tool`)? Do the numbers add up correctly? If not, review your loop logic.

17. Open the app in your browser and switch to the **Dashboard** view. You should now see:
    - The *"Summary not yet available"* message is **gone**
    - A **verdict breakdown doughnut chart** with colored slices for each verdict
    - A **tool comparison stacked bar chart** showing each tool's verdict distribution
    - A **total experiment count** at the top

    > **If the dashboard still shows the "not available" message:** Open the browser DevTools console (F12) and look for errors. A common issue is the endpoint returning a different JSON shape than the frontend expects.

### Part E: Commit Your Changes

18. Stop the API server (`Ctrl+C`)

19. Stage and commit your changes:

    ```bash
    git add -A
    git commit -m "Implement /summary endpoint, closes #1"
    ```

    > **Why reference an issue?** Using `closes #1` in the commit message will automatically close issue #1 when this commit is merged to the default branch. If you don't have an issue #1, just use a descriptive message like `"Implement /summary endpoint"`.

20. Push your changes:

    ```bash
    git push
    ```

---

## What You Should Have by the End

### Node — `node/server.js` (summary endpoint only)

The `/summary` route handler should be replaced from the 501 stub to working aggregation logic. Here is what the implementation should look like:

```javascript
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
app.get("/summary", (req, res) => {
  // Read all experiments and aggregate counts by verdict and by tool
  const experiments = readExperiments();

  const byVerdict = { Faster: 0, Same: 0, Slower: 0, Surprising: 0 };
  const byTool = {};

  for (const exp of experiments) {
    // Count by verdict
    if (exp.verdict in byVerdict) {
      byVerdict[exp.verdict]++;
    }

    // Count by tool, grouped by verdict
    if (!byTool[exp.tool]) {
      byTool[exp.tool] = { Faster: 0, Same: 0, Slower: 0, Surprising: 0 };
    }
    if (exp.verdict in byTool[exp.tool]) {
      byTool[exp.tool][exp.verdict]++;
    }
  }

  res.json({
    total: experiments.length,
    by_verdict: byVerdict,
    by_tool: byTool,
  });
});
```

### Python — `python/app.py` (summary endpoint only)

```python
@app.route("/summary", methods=["GET"])
def get_summary():
    """Aggregated experiment data."""
    # Read all experiments and aggregate counts by verdict and by tool
    experiments = read_experiments()

    by_verdict = {"Faster": 0, "Same": 0, "Slower": 0, "Surprising": 0}
    by_tool = {}

    for exp in experiments:
        verdict = exp.get("verdict", "")
        tool = exp.get("tool", "")

        # Count by verdict
        if verdict in by_verdict:
            by_verdict[verdict] += 1

        # Count by tool, grouped by verdict
        if tool not in by_tool:
            by_tool[tool] = {"Faster": 0, "Same": 0, "Slower": 0, "Surprising": 0}
        if verdict in by_tool[tool]:
            by_tool[tool][verdict] += 1

    return jsonify({
        "total": len(experiments),
        "by_verdict": by_verdict,
        "by_tool": by_tool,
    })
```

### .NET — `dotnet/Program.cs` (summary endpoint only)

```csharp
app.MapGet("/summary", () =>
{
    // Read all experiments and aggregate counts by verdict and by tool
    var experiments = ReadExperiments();

    var verdicts = new[] { "Faster", "Same", "Slower", "Surprising" };
    var byVerdict = new Dictionary<string, int>();
    foreach (var v in verdicts) byVerdict[v] = 0;

    var byTool = new Dictionary<string, Dictionary<string, int>>();

    foreach (var exp in experiments)
    {
        var verdict = exp.TryGetValue("verdict", out var v) ? v.ToString() ?? "" : "";
        var tool = exp.TryGetValue("tool", out var t) ? t.ToString() ?? "" : "";

        // Count by verdict
        if (byVerdict.ContainsKey(verdict))
        {
            byVerdict[verdict]++;
        }

        // Count by tool, grouped by verdict
        if (!byTool.ContainsKey(tool))
        {
            byTool[tool] = new Dictionary<string, int>();
            foreach (var vv in verdicts) byTool[tool][vv] = 0;
        }
        if (byTool[tool].ContainsKey(verdict))
        {
            byTool[tool][verdict]++;
        }
    }

    return Results.Ok(new
    {
        total = experiments.Count,
        by_verdict = byVerdict,
        by_tool = byTool,
    });
});
```

### What the Dashboard Should Look Like

When the endpoint is working correctly:
- The **verdict doughnut chart** shows colored slices — green for Faster, blue for Same, red for Slower, amber for Surprising
- The **tool comparison bar chart** shows a stacked bar for each tool, with the same color coding
- The **total count** at the top matches the number of entries in the Log view

### What Should NOT Change

- The `readExperiments()` / `read_experiments()` / `ReadExperiments()` helper function — you reuse it, not rewrite it
- The other endpoints (`GET /entries`, `GET /entries/:id`, `POST /entries`) — leave them untouched
- The `frontend/` folder — the dashboard code already handles rendering the data

---

## Troubleshooting

| Problem | Likely Cause | Fix |
|---------|-------------|-----|
| Dashboard still shows "not available" | Endpoint still returns 501 | Make sure you deleted the `res.status(501)` / `return jsonify(...), 501` line |
| `curl` returns `{}` or partial data | Missing keys in the response | Ensure you return all three keys: `total`, `by_verdict`, and `by_tool` |
| All counts are zero | Loop logic doesn't match field names | Check that you're reading `exp.verdict` / `exp["verdict"]` exactly (case-sensitive) |
| Chart shows but with wrong numbers | Counting logic error | Verify each experiment is counted in both `by_verdict` *and* the correct `by_tool` group |
| Server crashes on start | Syntax error in your code | Read the error message in the terminal — it will show the line number |
| `by_tool` is empty | Tool names have spaces or special chars | This is fine — tool names like `"Copilot config files"` are valid object keys |
| .NET endpoint returns wrong JSON shape | JsonSerializer casing | .NET `Results.Ok()` uses camelCase by default; the frontend handles both camelCase and snake_case |

**Expected output:** The `/summary` endpoint returns 200 with the correct JSON shape. The dashboard displays charts instead of the "not yet available" message.

> **Tip:** If Copilot's inline completion does not give you what you want, try making the comment more specific about the data structure and the grouping logic. You can also use Copilot Chat to ask for help.

You're making excellent progress — the dashboard coming to life is one of the most satisfying moments in the workshop! 🎉

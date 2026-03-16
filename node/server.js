const express = require("express");
const cors = require("cors");
const { v4: uuidv4 } = require("uuid");
const fs = require("fs");
const path = require("path");

const app = express();
const PORT = 3000;
const DATA_FILE = path.join(__dirname, "..", "data", "experiments.json");

app.use(cors());
app.use(express.json());

// Serve the frontend as static files
app.use(express.static(path.join(__dirname, "..", "frontend")));

// Helper: read experiments from JSON file
function readExperiments() {
  const raw = fs.readFileSync(DATA_FILE, "utf-8");
  return JSON.parse(raw);
}

// Helper: write experiments to JSON file
function writeExperiments(data) {
  fs.writeFileSync(DATA_FILE, JSON.stringify(data, null, 2));
}

// GET /entries — return all log entries
app.get("/entries", (req, res) => {
  const experiments = readExperiments();
  res.json(experiments);
});

// GET /entries/:id — return one entry by id
app.get("/entries/:id", (req, res) => {
  const experiments = readExperiments();
  const entry = experiments.find((e) => e.id === req.params.id);
  if (!entry) {
    return res.status(404).json({ error: "Entry not found" });
  }
  res.json(entry);
});

// POST /entries — add a new entry
app.post("/entries", (req, res) => {
  const { tool, task, expected, actual, verdict } = req.body;
  if (!tool || !task || !expected || !actual || !verdict) {
    return res.status(400).json({ error: "All fields are required: tool, task, expected, actual, verdict" });
  }

  const experiments = readExperiments();
  const newEntry = {
    id: `exp-${uuidv4().slice(0, 8)}`,
    tool,
    task,
    expected,
    actual,
    verdict,
    timestamp: new Date().toISOString(),
  };
  experiments.push(newEntry);
  writeExperiments(experiments);
  res.status(201).json(newEntry);
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
app.get("/summary", (req, res) => {
  res.status(501).json({ error: "Not implemented — build this in Lab 2!" });
});

app.listen(PORT, () => {
  console.log(`AI Experiment Log API running on http://localhost:${PORT}`);
});

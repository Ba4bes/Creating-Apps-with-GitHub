# Lab 2 — Core Guided: Implement the Summary Endpoint

**Goal:** Use Copilot inline completion to implement the `GET /summary` endpoint, unlocking the dashboard charts.

**Time:** 35 minutes

**You will need:** Lab 1 completed, Copilot instructions file in place, API running in your Codespace.

---

## Steps

1. **Add some entries first** — open the app in your browser, go to the Add Entry view, and add 3–4 experiments with different tools and verdicts. This makes the chart more interesting once it works.

2. Open your API file:
   - Node: `node/server.js`
   - Python: `python/app.py`
   - .NET: `dotnet/Program.cs`

3. Find the `/summary` endpoint — look for the 501 stub with the block comment describing the expected JSON shape

4. Read the comment carefully. The expected output looks like:
   ```json
   {
     "total": 6,
     "by_verdict": { "Faster": 3, "Same": 1, "Slower": 1, "Surprising": 1 },
     "by_tool": {
       "Copilot Inline": { "Faster": 2, "Same": 1, "Slower": 0, "Surprising": 0 },
       "Copilot Chat": { "Faster": 1, "Same": 0, "Slower": 1, "Surprising": 1 }
     }
   }
   ```

5. Delete the `res.status(501)` line (or the equivalent in your language)

6. Start writing a descriptive comment above the implementation area, for example:
   - Node: `// Read all experiments and aggregate counts by verdict and by tool`
   - Python: `# Read all experiments and aggregate counts by verdict and by tool`
   - .NET: `// Read all experiments and aggregate counts by verdict and by tool`

7. Press `Enter` and let Copilot suggest the implementation via inline completion (`Tab` to accept). Your instructions file from Lab 1 should influence the code style.

8. If the suggestion is incomplete, continue typing to give Copilot more context and accept additional suggestions.

9. Save the file and restart the API server

10. Open the app in your browser and switch to the Dashboard view — you should now see:
    - A verdict breakdown doughnut chart
    - A stacked bar chart comparing tools
    - A total experiment count

11. Commit your changes with a message referencing an issue (e.g., `Implement /summary endpoint, closes #1`)

**Expected output:** The `/summary` endpoint returns 200 with the correct JSON shape. The dashboard displays charts instead of the "not yet available" message.

> **Tip:** If the inline completion does not give you what you want, try making the comment more specific about the data structure and the grouping logic.

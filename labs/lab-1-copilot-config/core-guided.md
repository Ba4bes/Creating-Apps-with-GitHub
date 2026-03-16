# Lab 1 — Core Guided: Create Copilot Instructions & Prompt Files

**Goal:** Create a `copilot-instructions.md` and a `feature.prompt.md` that shape Copilot's output for your repo, then verify with inline completion.

**Time:** 35 minutes

**You will need:** Lab 0 completed, Codespace open, your language folder chosen.

---

## Steps

1. In the root of your repo, create the file `.github/copilot-instructions.md`
2. Add the following sections (adapt the content for your chosen language):

   ```markdown
   ## Language

   I am working in the [node/python/dotnet] folder of this repo.

   ## Code style

   - Use async/await instead of callbacks or raw promises
   - Add a brief comment above every function explaining what it does
   - Use descriptive variable names, not abbreviations

   ## Testing

   - Always suggest a test alongside any new function
   - Use [Jest/pytest/xUnit] as the test framework
   ```

3. Save the file. Copilot picks this up immediately — no restart required.
4. Create the folder `.github/prompts/` in the repo root
5. Create the file `.github/prompts/feature.prompt.md`
6. Add a prompt that describes how to implement a new API endpoint:

   ```markdown
   # Implement a new API endpoint

   When implementing a new endpoint for the AI Experiment Log API:

   1. Read the existing data from `/data/experiments.json`
   2. Process the data according to the endpoint's purpose
   3. Return JSON with appropriate status codes
   4. Follow the patterns in the existing endpoints in the server file
   5. Include error handling for missing or malformed data
   ```

7. Save the file
8. Open the API file for your language (`node/server.js`, `python/app.py`, or `dotnet/Program.cs`)
9. Position your cursor on an empty line inside the file
10. Start typing a comment like `// Calculate the average` or `# Calculate the average` — watch how Copilot's inline suggestion reflects the style rules from your instructions file
11. Accept a suggestion with `Tab` and observe the output

**Expected output:** A `copilot-instructions.md` and at least one prompt file committed to your repo. One piece of Copilot-assisted code written using only inline completion (zero premium requests).

> **Important:** What you write in these files now is what Copilot uses in Lab 2. Take the time to make them accurate.

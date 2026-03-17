# Lab 1 — Challenge Guided: Test Prompt File & Review Checklist

**Goal:** Create a test prompt file, compare Chat output with and without prompt files, and add a review checklist to your instructions.

**Time:** 25 minutes

**You will need:** Lab 1 Core completed (instructions file and feature prompt file exist).

---

## Steps

1. Create a new file: `.github/prompts/test.prompt.md`
2. Add content describing how tests should be structured:

   ```markdown
   # Write a test

   When writing tests for the AI Experiment Log API:

   - Use [Jest/pytest/xUnit] as the framework
   - Place test files in [node/__tests__/ | python/tests/ | dotnet/Api.Tests/]
   - Name test files with a clear suffix: [*.test.js | test_*.py | *Tests.cs]
   - Each test should: arrange test data, act by calling the function, assert the expected result
   - Test both the happy path and at least one error case
   ```

3. Save the file
4. Open Copilot Chat and ask: "Write a test for the GET /entries endpoint" — **without** attaching the test prompt file. Note the output style and quality.
5. Now ask the same question again, but this time attach `test.prompt.md` as context (use `#file` to reference it). Compare the two outputs side by side.
6. Open your `.github/copilot-instructions.md`
7. Add a new section:

   ```markdown
   ## Review checklist

   When reviewing code, always check:
   - [ ] Error handling for missing or invalid input
   - [ ] Consistent use of the code style rules above
   - [ ] At least one test covers the new functionality
   ```

8. Save the file

**Expected output:** A `test.prompt.md` committed, a visible comparison of Chat output with and without prompt file context, and a review checklist in your instructions file.

> **Note:** Steps 4–5 use Copilot Chat and consume premium requests. If you are on the free tier, you can skip the comparison and trust that prompt files improve output quality.

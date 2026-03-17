# Lab 2 — Challenge Guided: Validation, Tests, and Agent Comparison

**Goal:** Add input validation to the POST endpoint, write your first test, and optionally compare with the coding agent's output.

**Time:** 25 minutes

**You will need:** Lab 2 Core completed (summary endpoint working).

---

## Steps

### Part A: Validation via Chat Review

1. Select the code for your `POST /entries` endpoint
2. Open Copilot Chat and ask: "Review this endpoint for input validation issues. What edge cases are not handled?"
3. Apply any suggestions that make sense (e.g., string length limits, allowed verdict values, XSS prevention)

### Part B: Write Your First Test

4. Create a test file in the appropriate location:
   - Node: `node/__tests__/summary.test.js`
   - Python: `python/test_summary.py`
   - .NET: `dotnet/Api.Tests/SummaryTests.cs`

5. Write one test that verifies the `/summary` endpoint returns the correct shape. Use Copilot to help — try attaching your `test.prompt.md` as context.

6. Run the test:
   ```bash
   # Node
   cd node && npm test

   # Python
   cd python && pytest

   # .NET
   cd dotnet/Api.Tests && dotnet test
   ```

7. Verify the test passes

### Part C: Compare with Coding Agent (optional)

8. If your instructor started a coding agent session earlier, check if a PR has been created in your repo
9. Compare the agent's implementation of `/summary` with your own — what is different? What is similar?

**Expected output:** Improved validation on the POST endpoint, at least one passing test, and an understanding of how your implementation compares to an automated one.

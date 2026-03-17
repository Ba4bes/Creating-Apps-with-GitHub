# Lab 3 — Challenge Guided: Multi-Version Matrix and Intentional Failure

**Goal:** Expand the CI matrix to test multiple versions, add a lint step, and verify CI catches a deliberate bug.

**Time:** 25 minutes

**You will need:** Lab 3 Core completed (CI green, Pages deployed).

---

## Steps

### Part A: Multi-Version Matrix

1. Open `.github/workflows/ci.yml`
2. For your chosen language, add a version matrix. For example, for Node:
   ```yaml
   node:
     name: Node.js
     runs-on: ubuntu-latest
     strategy:
       matrix:
         node-version: [18, 20, 22]
     defaults:
       run:
         working-directory: node
     steps:
       - uses: actions/checkout@v4
       - uses: actions/setup-node@v4
         with:
           node-version: ${{ matrix.node-version }}
       - run: npm ci
       - run: npm test
   ```
3. Commit and push. Watch the matrix expand in the Actions tab.

### Part B: Add a Lint Step

4. Uncomment or add the lint step for your language:
   - **Node:** `npx eslint .` (you may need to add an `.eslintrc.json` config)
   - **Python:** `pip install ruff && ruff check .`
   - **.NET:** Build warnings are checked during `dotnet build`
5. Fix any lint errors and push again

### Part C: Intentional Bug

6. Introduce a deliberate syntax error in your API file (e.g., remove a closing bracket)
7. Commit and push to a new branch
8. Open a PR and verify that CI catches the error and the check fails
9. Fix the bug, push again, verify CI goes green
10. **Do not merge this PR** — its purpose is to demonstrate that CI protects main

**Expected output:** CI runs across multiple versions, lint is active, and you have demonstrated that CI catches bugs before they reach main.

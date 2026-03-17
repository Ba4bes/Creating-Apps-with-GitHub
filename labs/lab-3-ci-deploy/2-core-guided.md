# Lab 3 — Core Guided: Enable CI and Deploy to GitHub Pages

**Goal:** Activate the CI and deploy workflows, get a green build, and publish your app to a live URL.

**Time:** 35 minutes

**You will need:** Lab 2 completed, changes committed and pushed.

---

## Steps

### Part A: Set Up GitHub Pages

1. In your fork on github.com, go to **Settings → Pages**
2. Under **Source**, select **GitHub Actions**
3. This tells GitHub to use the deploy workflow rather than serving from a branch

### Part B: Enable CI on Push

4. Open `.github/workflows/ci.yml` in your Codespace
5. Find the `on:` section at the top — currently it only has `workflow_dispatch`
6. Change it to trigger on push as well:
   ```yaml
   on:
     workflow_dispatch:
     push:
       branches: [main]
   ```
7. Save the file

### Part C: Adjust the CI Matrix (your language only)

8. The CI workflow runs all three languages. For now, you only need your chosen language to pass.
9. Review the job for your language and make sure the steps are correct:
   - **Node:** `npm ci` → `npm test`
   - **Python:** `pip install -r requirements.txt` → `pytest --tb=short`
   - **.NET:** `dotnet restore` → `dotnet build --no-restore` → `cd Api.Tests && dotnet test --no-build`

### Part D: Create a PR

10. Create a new branch:
    ```bash
    git checkout -b enable-ci
    ```
11. Commit the workflow change:
    ```bash
    git add .github/workflows/ci.yml
    git commit -m "Enable CI on push"
    ```
12. Push the branch:
    ```bash
    git push origin enable-ci
    ```
13. On github.com, open a Pull Request from `enable-ci` into `main`
14. Watch the CI workflow run in the PR checks — wait for it to go green
15. If any job fails, read the error log, fix the issue, commit, and push again

### Part E: Enable Deploy and Merge

16. Open `.github/workflows/deploy.yml`
17. Add a push trigger the same way you did for CI:
    ```yaml
    on:
      workflow_dispatch:
      push:
        branches: [main]
    ```
18. Commit and push this change to your `enable-ci` branch
19. Once CI is green, merge the PR
20. Go to **Actions** tab and watch the deploy workflow run
21. Once complete, go to **Settings → Pages** and find your live URL (typically `https://<username>.github.io/<repo>/`)
22. Visit the URL and verify your app is live

**Expected output:** CI passes on every push. Your frontend is deployed to GitHub Pages at a live URL. The dashboard shows "Summary not yet available" (because the static site does not have a backend — this is expected for Pages).

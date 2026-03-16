# Lab 3 — Core Self-Directed: Enable CI and Deploy to GitHub Pages

**Goal:** Activate both workflows on push, get a green build via PR, and deploy your app to a live GitHub Pages URL.

**Time:** 35 minutes

**You will need:** Lab 2 completed, changes committed and pushed.

---

## Your Task

Both workflow files (`.github/workflows/ci.yml` and `deploy.yml`) exist but only trigger on `workflow_dispatch`. Add `push` triggers, set the Pages source to GitHub Actions, create a PR to verify CI passes, then merge and verify the deploy produces a live URL.

## Success Criteria

- CI runs automatically on push to main
- All three language jobs pass (or at minimum your chosen language)
- The deploy workflow runs after merge
- Your frontend is live at `https://<username>.github.io/<repo>/`
- The app loads in the browser at the live URL

# Lab 3 — Challenge Self-Directed: Advanced CI Configuration

**Goal:** Expand CI with multi-version testing, linting, and demonstrate that CI catches deliberate errors.

**Time:** 25 minutes

**You will need:** Lab 3 Core completed (CI green, Pages deployed).

---

## Your Task

Add a version matrix to your language's CI job so it tests across multiple runtime versions. Enable the lint step. Then introduce a deliberate bug, push it on a branch, and verify CI catches it before it reaches main.

## Success Criteria

- CI matrix runs at least 2 versions of your chosen language
- A lint step runs as part of CI
- You have a PR where CI correctly failed on a deliberate bug
- Main remains green and deployed

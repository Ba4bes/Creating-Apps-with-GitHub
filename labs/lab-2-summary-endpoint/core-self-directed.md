# Lab 2 — Core Self-Directed: Implement the Summary Endpoint

**Goal:** Implement the `GET /summary` endpoint using Copilot inline completion so the dashboard charts work.

**Time:** 35 minutes

**You will need:** Lab 1 completed, Copilot instructions file in place, API running.

---

## Your Task

Find the 501 stub for the `/summary` endpoint in your language's API file. The block comment above it describes the expected JSON response shape. Replace the stub with working aggregation logic. Use Copilot inline completion — write a descriptive comment and let Copilot suggest the implementation.

Add some entries through the frontend first so the charts have interesting data.

## Success Criteria

- `GET /summary` returns 200 with a JSON body containing `total`, `by_verdict`, and `by_tool`
- The dashboard view shows a verdict breakdown chart and a tool comparison chart
- The "Summary not yet available" message is gone
- Changes committed with a message referencing an issue

> **Tip:** Add entries with different tools and verdicts before implementing the endpoint.

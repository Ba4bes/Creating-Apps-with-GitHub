# Creating Apps with GitHub — AI Experiment Log

A hands-on workshop where you fork this repo, open a Codespace, and across four labs: configure Copilot, implement a feature, and deploy to GitHub Pages. By the end of the day you have a live personal dashboard showing your AI experiment results.

## What You Build

An **AI Experiment Log** — a web app that tracks your experiments with AI coding tools. Each entry records the tool you used, what you tried, what happened, and your verdict. The app includes:

- A scrollable log of all experiments
- A dashboard with verdict breakdown and tool comparison charts
- A form to add new entries
- An API that reads/writes a JSON data file

The repo ships three backend implementations (Node, Python, .NET) so you can pick the language you are most comfortable with.

## Repository Structure

```
├── .devcontainer/          # Codespace configuration (Node 20, Python 3.12, .NET 8)
├── .github/
│   ├── ISSUE_TEMPLATE/     # Feature request template
│   └── workflows/          # CI and deploy workflows (workflow_dispatch)
├── data/
│   └── experiments.json    # Shared data file (2 starter entries)
├── frontend/               # SPA (HTML + JS + CSS, Chart.js)
├── node/                   # Express API on port 3000
├── python/                 # Flask API on port 5000
├── dotnet/                 # ASP.NET Core API on port 5001
└── labs/                   # Lab instructions (0–3)
```

## Quick Start

### 1. Fork & Open in Codespaces

1. Click **Fork** at the top of this repo
2. In your fork, click **Code → Codespaces → Create codespace on main**
3. Wait for the container to build (installs all three language dependencies)

### 2. Run Your Chosen Language

**Node (port 3000):**
```bash
cd node && npm start
```

**Python (port 5000):**
```bash
cd python && flask run --port 5000
```

**.NET (port 5001):**
```bash
cd dotnet && dotnet run
```

### 3. Open the Frontend

Once the API is running, click the globe icon next to the forwarded port in the **Ports** tab. You should see the app with two starter entries and a "Summary not yet available" message on the dashboard.

> **Note:** The frontend defaults to `http://localhost:3000`. If you are using Python or .NET, update the `API_BASE` variable in `frontend/app.js` to match your port.

## Copilot Free Tier

This workshop is designed to work with the **Copilot free tier** (2,000 completions + 50 premium requests/month). All Core labs are completable using inline completions only — zero premium requests required.

Want unlimited chat for today? GitHub offers a [30-day free Copilot Pro trial](https://github.com/settings/copilot).

## Labs Overview

| Lab | Topic | Time |
|-----|-------|------|
| [Lab 0](labs/lab-0-codespaces/) | Codespaces — fork, launch, run | 55 min |
| [Lab 1](labs/lab-1-copilot-config/) | Copilot config — instructions & prompt files | 60 min |
| [Lab 2](labs/lab-2-summary-endpoint/) | Feature — implement the summary endpoint | 60 min |
| [Lab 3](labs/lab-3-ci-deploy/) | CI/Deploy — workflows & GitHub Pages | 60 min |

Each lab has **Core** (everyone completes) and **Challenge** (stretch goal) tiers, each available in **Guided** (step-by-step) or **Self-directed** (goal only) mode.

## Test Frameworks

Test frameworks are pre-installed but no test files exist yet — writing your first test is a Lab 2 challenge.

```bash
# Node (Jest)
cd node && npm test

# Python (pytest)
cd python && pytest

# .NET (xUnit)
cd dotnet/Api.Tests && dotnet test
```
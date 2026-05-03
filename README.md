# Creating Apps with GitHub — AI Experiment Log

A hands-on workshop where you create a repo from this template, open a Codespace, and across five labs: set up your dev environment, configure Copilot, implement a feature, build a CI workflow, and deploy to GitHub Pages. By the end of the day you have a live personal dashboard showing your AI experiment results.

## What You Build

An **AI Experiment Log** — a web app that tracks your experiments with AI coding tools. Each entry records the tool you used, what you tried, what happened, and your verdict. The app includes:

- A scrollable log of all experiments
- A dashboard with verdict breakdown and tool comparison charts
- A form to add new entries
- An API that reads/writes a JSON data file

The repo ships three backend implementations (Node, Python, .NET) so you can pick the language you are most comfortable with.

## Repository Structure

```
├── .devcontainer/          # Minimal Codespace base — you add your language in Lab 0
├── .github/
│   ├── ISSUE_TEMPLATE/     # Feature request template
│   └── workflows/          # CI and deploy workflows (manual-only until Labs 3–4)
├── data/
│   └── experiments.json    # Shared data file (2 starter entries)
├── frontend/               # SPA (HTML + JS + CSS, Chart.js from CDN)
├── node/                   # Express API on port 3000
├── python/                 # Flask API on port 5000
├── dotnet/                 # ASP.NET Core API on port 5001
├── rescue/                 # Completed Lab 2 files for the time-boxed sprint
└── labs/                   # Lab instructions (0–4)
```

## Quick Start

### 1. Create Your Repo & Open in Codespaces

1. Click **Use this template → Create a new repository** at the top of this repo
2. In your new repo, click **Code → Codespaces → Create codespace on main**
3. The container starts with a minimal base image — Lab 0 walks you through adding your chosen language

### 2. Run Your Chosen Language

**Node (port 3000):**

```bash

cd node

npm install

npm start
```

**Python (port 5000):**

```bash
cd python

pip install -r requirements.txt

python -m flask run --port 5000
```

**.NET (port 5001):**

```bash
cd dotnet 
dotnet run
```

### 3. Open the Frontend

Each backend serves the frontend itself on its own port. Click the globe icon next to the forwarded port in the **Ports** tab. You should see the app with two starter entries and a placeholder on the Tool Comparison chart (you wire that up in Lab 2).

## Copilot Free Tier

This workshop is designed to work with the **Copilot free tier** (2,000 completions + 50 premium requests/month). All Core labs are completable using inline completions only — zero premium requests required.

Want unlimited chat for today? GitHub offers a [30-day free Copilot Pro trial](https://github.com/settings/copilot).

## Labs Overview

| Lab                                   | Topic                                                  | Time   |
| ------------------------------------- | ------------------------------------------------------ | ------ |
| [Lab 0](labs/lab-0-codespaces/)       | Codespaces — template, launch, customize devcontainer  | 45 min |
| [Lab 1](labs/lab-1-copilot-config/)   | Copilot config — instructions, skills & plugins        | 60 min |
| [Lab 2](labs/lab-2-summary-endpoint/) | Feature — implement the summary endpoint (core sprint) | 30 min |
| [Lab 3](labs/lab-3-ci-deploy/)        | CI — workflow structure, triggers & jobs               | 45 min |
| [Lab 4](labs/lab-4-deploy/)           | Deploy — GitHub Pages & Marketplace actions            | 45 min |

Each lab has **Core** (everyone completes) and **Challenge** (stretch goal) tiers, each available in **Guided** (step-by-step) or **Self-directed** (goal only) mode.

## Test Frameworks

A single shape test is provided per language; writing more tests is a Lab 2 challenge.

```bash
# Node (Jest)
cd node && npm test

# Python (pytest)
cd python && pytest

# .NET (xUnit)
cd dotnet/Api.Tests && dotnet test
```

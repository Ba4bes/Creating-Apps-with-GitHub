# Lab 0 — Challenge Self-Directed: Customize Your Dev Container

**Goal:** Extend `.devcontainer/devcontainer.json` with a VS Code extension, a CLI tool, and a VS Code setting.

**Time:** 25 minutes

**You will need:** Lab 0 Core completed (you have a Codespace running).

> if you are stuck, open the guided lab [here](../lab-0-codespaces/4-challenge-guided.md) for step-by-step instructions.   

---

## Your Task

Open a new Codespace.

Modify `.devcontainer/devcontainer.json` to add:

1. The GitHub Copilot VS Code extension (`github.copilot`)
2. The Azure CLI as a dev container feature
3. A VS Code setting that hides the minimap

Rebuild the container on every step and verify all three changes are applied.

## Success Criteria

- The GitHub Copilot extension is installed and visible in the Extensions sidebar
- Running `az --version` in the terminal succeeds
- The minimap is no longer visible on the right side of the editor

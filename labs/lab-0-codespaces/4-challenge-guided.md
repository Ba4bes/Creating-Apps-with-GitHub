# Lab 0 — Challenge Guided: Customize Your Codespace

**Goal:** Modify the devcontainer configuration and explore the multi-language repo structure.

**Time:** 25 minutes

**You will need:** Lab 0 Core completed (Codespace running with the app visible).

---

## Steps

1. In the Codespace, open `.devcontainer/devcontainer.json`
2. Find the `extensions` array inside `customizations.vscode`
3. Add one VS Code extension you actually use — find the extension ID from the [VS Code Marketplace](https://marketplace.visualstudio.com/vscode). For example:
   - `"esbenp.prettier-vscode"` for Prettier
   - `"streetsidesoftware.code-spell-checker"` for spell checking
4. Save the file
5. Open the Command Palette (`Ctrl+Shift+P` / `Cmd+Shift+P`) and run **Codespaces: Rebuild Container**
6. Wait for the rebuild to complete
7. Verify that your added extension appears in the Extensions sidebar after rebuild
8. Browse through the three language folders (`node/`, `python/`, `dotnet/`) and answer these questions:
   - What is shared between all three implementations? (data file, frontend)
   - What is different? (server file, dependency file, port number)
   - Where does each API read the experiment data from?

**Expected output:** Your devcontainer has a new extension, and you understand how the three language implementations relate to each other and to the shared frontend.

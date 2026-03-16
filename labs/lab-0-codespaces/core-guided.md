# Lab 0 — Core Guided: Launch Your Codespace

**Goal:** Fork the workshop repo, open a Codespace, and see the running app in your browser.

**Time:** 30 minutes

**You will need:** A GitHub account with Codespaces access (included in free tier).

---

## Steps

1. Go to the workshop repo URL (shown on screen or shared by the instructor)
2. Click **Fork** in the top-right corner, accept the default settings, and click **Create fork**
3. In your fork, click the green **Code** button → **Codespaces** tab → **Create codespace on main**
4. Wait for the Codespace to open — this typically takes 60–90 seconds while the container builds and installs dependencies for all three languages
5. Once the terminal prompt appears, start the API for your chosen language:

   **Node:**
   ```bash
   cd node && npm start
   ```

   **Python:**
   ```bash
   cd python && flask run --port 5000
   ```

   **.NET:**
   ```bash
   cd dotnet && dotnet run
   ```

6. Click the **Ports** tab at the bottom of the Codespace
7. Find the forwarded port (3000, 5000, or 5001) and click the globe icon to open it in a new browser tab
8. You should see the AI Experiment Log app with:
   - Two starter entries in the Log view
   - A form in the Add Entry view
   - A "Summary not yet available" message in the Dashboard view

**Expected output:** The app is visible in your browser with two pre-populated experiment entries.

> **Troubleshooting:** If the Codespace fails to start, clone the repo locally and run the same start command. Open the `frontend/index.html` separately or use a local server.

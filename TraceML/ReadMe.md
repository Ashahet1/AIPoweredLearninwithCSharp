

# TraceML

**TraceML** is a web-based tool to **track and estimate carbon emissions generated specifically by using or training AI/ML models**.

The goal is to help developers and researchers understand the environmental cost of AI workloads and make more sustainable choices.

---

## 🌍 What This Is NOT
- This is **not** about household electricity usage.
- This is **not** about CO₂ based on your location or grid intensity.

---

## 🎯 What This Project Does

- Tracks **when** and **how long** your AI model runs.
- Estimates **energy consumption** based on the device used (CPU/GPU).
- Converts that energy into **CO₂ emissions** using known hardware power usage.
- Logs all emissions to a backend.
- Shows results in a simple **web dashboard**.

---

## 🛠️ Tech Stack

| Component      | Choice          |
|----------------|-----------------|
| Frontend       | React (Web UI)  |
| Backend        | C# (.NET) or Node.js (to be finalized) |
| Estimation     | Custom `TraceML` logger (like CodeCarbon) |
| Storage        | Lightweight DB or JSON (initially) |

---

## 📦 Planned Features (MVP)

- [ ] Create TraceML wrapper to log model usage and time.
- [ ] Estimate energy based on hardware (e.g., A100 GPU vs CPU).
- [ ] Calculate carbon emissions from energy usage.
- [ ] Store usage data in backend.
- [ ] Build simple dashboard to display:
  - Total emissions
  - Per-model footprint
  - Trend over time

---

## 🗂️ Project Structure (Coming Soon)

```
traceml/
├── frontend/         # React dashboard
├── backend/          # C# or Node.js API to store usage logs
├── traceml-core/     # Emission estimation logic
├── docs/             # Architecture diagrams and references
└── README.md         # You're here!
```

---

## ✍️ Notes

- This is a work-in-progress side project.
- Primary focus is on **AI model emissions**, not full infrastructure monitoring.
- Goal is to eventually offer this as an open-source library + dashboard combo.

---

## 📅 Next Steps

- [ ] Finalize backend language (C# or Node.js)
- [ ] Build first version of emission estimation module
- [ ] Log mock usage of a sample ML model (e.g., `myModel.predict()`)
- [ ] Setup simple React UI for displaying usage logs

---



# Incident Root-Cause Analysis Agent

## 📌 Problem
IT operations teams deal with system incidents daily — services crash, network fails, queues build up, APIs hit rate limits, and tokens expire.  
Finding the **root cause** often means digging through logs, running multiple checks, and piecing together clues manually.  
This is **time-consuming, repetitive, and error-prone**.

## 💡 Our Solution
We’re building an **AI-powered Incident Root-Cause Analysis Agent** that:
1. Receives an incident alert (e.g., “service down” or “API failing”)
2. Uses **diagnostic tools** to gather the right evidence (logs, metrics, configs)
3. Identifies the **most likely root cause**
4. Produces a **clear, short remediation plan**

We use Microsoft’s **`Microsoft.Extensions.AI.Evaluation`** libraries to:
- **Agent Quality Evaluators** – check if the AI uses the correct tools, in the correct order, and stays on task.
- **NLP Evaluators** – check if its explanation matches a gold-standard answer for clarity and accuracy.

## 🛠️ Issues Covered in Version 1
| Issue | Core Tool(s) | Purpose |
|-------|--------------|---------|
| CrashLoopBackOff | kind/minikube, kubectl, Docker | Run Kubernetes locally & simulate pod restart loops |
| DNS Failure | curl, dig/nslookup | Trigger & verify DNS errors |
| Queue Backlog | Redpanda/Kafka or RabbitMQ (Docker) | Simulate message queue lag |
| Rate Limit Exceeded | Nginx (rate-limit) or mock API | Return 429 errors after N requests |
| Token Expired | JWT generator or expired token | Simulate auth failures (401/403) |

## 🚀 How It Works
1. **Incident Simulation** – We recreate realistic IT failures using local tools and sample logs.
2. **Tool Calls** – The AI agent uses pre-defined “functions” (e.g., `GetRecentLogs`, `CheckDiskUsage`) to investigate.
3. **Evaluation** – We run:
   - *Agent Quality tests* to verify correct investigation steps.
   - *NLP tests* to verify explanation quality.
4. **Reports** – `dotnet aieval` generates an easy-to-read HTML report with pass/fail results.

## 🎯 Goals
- Speed up incident investigation.
- Reduce human error in root cause analysis.
- Provide **auditable** and **repeatable** AI evaluations.

---

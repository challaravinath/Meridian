# ??? Meridian — Development Roadmap

> This roadmap reflects the current plan. It will evolve as the community grows and priorities shift. 
> Each milestone has a GitHub Project board linked below.

---

## How We Work

- Each milestone targets a working, usable release — no half-baked drops
- Every milestone closes with a blog post or write-up
- Breaking changes are avoided after v0.3; any breaking change requires an RFC
- All public APIs get XML documentation before shipping

---

## ? v0.1 — The Foundation
**Target: Week 1–2 | Theme: "It works"**

The goal is a working agent loop in .NET with no fluff. Anyone who clones the repo can run a working agent in 10 minutes.

### Deliverables
- [ ] Solution structure in Visual Studio 2022
  - `Meridian.Core` — class library
  - `Meridian.Samples.QuickStart` — console app
- [ ] `Meridian.Core` project
  - `IAgent` interface
  - `IAgentTool` interface  
  - `IMemoryStore` interface
  - `AgentContext` — shared state object
  - `AgentConfig` — config model
  - `MeridianAgent` — base implementation with ReAct loop
- [ ] `ClaudeClient` / `AzureOpenAIClient` wrapper (pluggable)
- [ ] First working console sample: natural language ? Claude ? response
- [ ] README with setup instructions for VS 2022 (no CLI assumed)
- [ ] GitHub Actions CI — build + test on push

### Definition of Done
> A developer with VS 2022 and an API key can clone, open solution, hit F5, and chat with an AI agent.

---

## ?? v0.2 — Real World Connections
**Target: Week 3–5 | Theme: "It connects"**

The agent gets eyes and hands — it can read Azure DevOps tickets and search SharePoint documents.

### Deliverables
- [ ] `Meridian.Connectors.AzureDevOps` project
  - Read work items (tickets, user stories, bugs)
  - Update work item state + add comments
  - Create branches via ADO API
  - Open Pull Requests
- [ ] `Meridian.Connectors.SharePoint` project
  - Authenticate via Microsoft.Identity / MSAL
  - Search documents by keyword
  - Read document content (Word, PDF, text)
  - Return as context chunks for agent
- [ ] Tool registration system — `IAgentTool` auto-discovery via DI
- [ ] Updated sample: agent reads a real ADO ticket + finds related SharePoint doc
- [ ] `appsettings.example.json` with all config documented
- [ ] Docs: [Setting up Azure DevOps connection](docs/connectors/azure-devops.md)
- [ ] Docs: [Setting up SharePoint connection](docs/connectors/sharepoint.md)

### Definition of Done
> Agent reads ticket ADO-1234 from your real Azure DevOps org, searches SharePoint for related specs, and summarises both.

---

## ?? v0.3 — Memory & Context
**Target: Week 6–8 | Theme: "It remembers"**

The agent gains memory — it learns from past interactions and builds a growing knowledge base.

### Deliverables
- [ ] `Meridian.Memory` project
  - `InMemoryStore` — for development and testing
  - `SqliteMemoryStore` — lightweight production option
  - `AzureAISearchMemoryStore` — production vector search
- [ ] Embedding pipeline — chunk documents, generate embeddings, store + retrieve
- [ ] `Meridian.Connectors.Excel` project
  - Read structured data from Excel/CSV reports
  - Pass tabular context to agent
- [ ] Semantic Kernel integration — replace raw API calls with SK kernel
- [ ] `Meridian.AspNetCore` project
  - `AddMeridian()` DI extension
  - `IAgentFactory` for DI-resolved agent creation
- [ ] Unit tests — 80%+ coverage on Core
- [ ] NuGet alpha packages published

### Definition of Done
> Agent remembers a ticket it worked on last week. Agent searches internal SharePoint by meaning, not just keywords.

---

## ?? v0.4 — Multi-Agent Orchestration
**Target: Week 9–11 | Theme: "It delegates"**

Agents that spawn and coordinate other agents. The orchestrator pattern.

### Deliverables
- [ ] `OrchestratorAgent` — breaks complex tasks into sub-tasks
- [ ] `SubAgentPool` — manages a pool of specialist agents
- [ ] Agent-to-agent communication protocol
- [ ] Built-in specialist agents:
  - `ResearcherAgent` — finds and summarises information
  - `CodeGeneratorAgent` — writes idiomatic C# code
  - `ReviewerAgent` — reviews code against standards
  - `DocumentationAgent` — generates XML docs, README updates
- [ ] `CodeRunnerTool` — runs C# snippets, captures output/errors
- [ ] `DebuggerTool` — reads compiler errors, suggests and applies fixes
- [ ] Integration tests — full agent loop with mocked connectors

### Definition of Done
> Orchestrator agent reads ADO ticket ? spawns researcher to find specs on SharePoint ? spawns coder to write implementation ? spawns reviewer to check against standards ? opens PR.

---

## ??? v0.5 — The Dashboard
**Target: Week 12–14 | Theme: "Your team can use it"**

A Blazor Server dashboard your team can actually use internally. This is the "DevAssistant" product built on top of Meridian.

### Deliverables
- [ ] `Meridian.Samples.DevAssistant` — Blazor Server app
  - Ticket queue view — list of ADO tickets
  - Agent activity log — live streaming of agent steps
  - Code diff preview — before/after with syntax highlighting
  - Settings page — configure connectors
- [ ] SignalR streaming — real-time agent step updates in UI
- [ ] Authentication — Windows Auth / Azure AD via MSAL
- [ ] Docker support — `Dockerfile` + `docker-compose.yml`
- [ ] Azure deployment template — one-click to Azure App Service
- [ ] Full end-to-end demo video in README

### Definition of Done
> A team of 5 devs uses DevAssistant internally for 2 weeks and finds it useful in daily work.

---

## ?? v1.0 — Community Launch
**Target: Week 15–20 | Theme: "The world can use it"**

Production-stable, fully documented, NuGet-published, community-ready.

### Deliverables
- [ ] Stable public API (no breaking changes after this)
- [ ] Full documentation site (Docusaurus on GitHub Pages)
  - Getting Started guide
  - Concept guides (agents, tools, memory, orchestration)
  - API reference (auto-generated from XML docs)
  - Connector guides
  - Deployment guides
- [ ] NuGet packages — all packages at v1.0.0
- [ ] Sample gallery — 3+ complete sample apps
- [ ] Community
  - Issue templates
  - PR templates
  - CONTRIBUTING.md
  - CODE_OF_CONDUCT.md
  - GitHub Discussions enabled
- [ ] Blog post / announcement
- [ ] Submit to Semantic Kernel community showcase

### Definition of Done
> A developer who has never seen this project before can go from zero to a running production agent in under 30 minutes using only the docs.

---

## ?? Post v1.0 Backlog (Not Committed)

These are ideas for later exploration — not committed to any timeline:

- Plugin marketplace / community connector registry
- GitHub connector (for teams migrating from ADO)
- ServiceNow connector
- Confluence/Notion connector
- Local model support via Ollama
- VS Code extension for agent-assisted coding
- Azure Functions hosting template
- gRPC-based multi-agent communication
- Agent performance benchmarking suite

---

## ?? Notes on This Roadmap

- Timelines are estimates for a solo developer; community contributions will accelerate this
- Each milestone may shift by 1–2 weeks — that's normal, not a failure
- Priorities can change based on community feedback — open a Discussion to advocate for something
- Security issues bypass the roadmap entirely and are fixed immediately

---


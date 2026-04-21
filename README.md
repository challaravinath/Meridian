# Meridian
### Enterprise Agentic AI Framework for .NET

[![Build](https://github.com/YOUR_USERNAME/Meridian/actions/workflows/ci.yml/badge.svg)](https://github.com/YOUR_USERNAME/Meridian/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com)

> Build production-grade AI agents in .NET — connected to Azure DevOps, GitHub, 
> SharePoint, and the tools your enterprise already runs on.

---

## Why Meridian?

Every agentic AI framework is Python-first. Enterprise .NET teams running Azure DevOps, 
SharePoint, and on-premise infrastructure are left behind.

Meridian fixes that.

- **Self-hosted** — your code never leaves your network
- **Semantic Kernel native** — builds on Microsoft's own AI SDK
- **Platform agnostic** — Azure DevOps and GitHub treated as equals
- **Enterprise connectors** — SharePoint, Excel, Azure AI Search out of the box
- **.NET first** — idiomatic C#, full DI support, async throughout

---

## The Problem We Solve

A senior .NET developer gets ticket ADO-1234 or GitHub Issue #567.
Today they read it, find the relevant code, write the fix, test it, 
open a PR, and update the ticket — manually, every time.

Meridian makes that a conversation:

```csharp
var result = await agent.RunAsync(
    "Fix the bug in ticket 1234, follow our coding standards, " +
    "and open a PR when done"
);
```

The agent reads the ticket, searches the codebase, finds the bug,
writes idiomatic C# code, runs the tests, and opens the PR —
connected to your actual Azure DevOps or GitHub.

---

## The Provider Pattern

Agents never talk to Azure DevOps or GitHub directly.
They talk to `ISourceControlProvider` — and you decide at startup which 
platform backs it:

```csharp
// Azure DevOps shop
builder.Services.AddMeridian(options =>
    options.UseAzureDevOps(config["ADO:OrgUrl"]));

// GitHub shop
builder.Services.AddMeridian(options =>
    options.UseGitHub(config["GitHub:Token"]));

// Both — common during enterprise migrations
builder.Services.AddMeridian(options => options
    .UseAzureDevOps(config["ADO:OrgUrl"])
    .UseGitHub(config["GitHub:Token"]));
```

Same agent code. Zero changes. Just config.

---

## Setup (Visual Studio 2022)

---

## Current State — v0.1 Alpha 🚧

Actively being built in public. Follow along.

### ✅ Done
- Solution structure and project layout
- Neutral source control models
  - `WorkItem` — platform-agnostic ticket model
  - `PullRequest` — works for ADO and GitHub equally
  - `Repository` — neutral repo representation
  - `Branch` — with protected branch awareness
- `ISourceControlProvider` — the core contract every provider implements
  - Full `CancellationToken` support for agent loop control
  - Works for Azure DevOps, GitHub, or both simultaneously

### 🔄 In Progress
- `IAgent` and `IAgentTool` — the agent loop contracts
- `MeridianAgent` — the ReAct loop implementation
- `AgentContext` — shared memory across agent steps

### 📋 Coming Next
- Azure DevOps provider implementation
- GitHub provider implementation  
- SharePoint document provider
- Multi-agent orchestration
- Blazor dashboard

See [ROADMAP.md](ROADMAP.md) for the full plan.

---

## Architecture - Mental Model

<img width="1229" height="849" alt="image" src="https://github.com/user-attachments/assets/4f221b8b-740a-4032-b654-191d94404f7c" />
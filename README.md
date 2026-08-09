# 🎮 HiroForgeProject

> A Unity-based development workspace by HiroForge Studios, combining a custom editor framework (HFDK) with a scalable game architecture for AI-assisted development.

---

## 🧠 Overview

HiroForgeProject is a unified Unity project that contains both:

- 🛠️ **HFDK (HiroForge Dev Kit)** — a custom Unity editor framework
- 🎮 **Game systems** — modular gameplay architecture under development

This setup allows fast iteration, clean structure, and powerful AI-assisted workflows using tools like Cursor.

---

## 🏗️ Project Structure
Assets/
│
├── Editor/
│ └── HiroForge/
│ └── HFDK/
│ ├── HF.RefactorEngine/
│ │ ├── Analysis/
│ │ ├── Application/
│ │ ├── Domain/
│ │ ├── Infrastructure/
│ │ ├── Scanning/
│ │ └── Preview/
│ │
│ ├── DesignSystem/
│ ├── Widgets/
│ ├── UI/
│ ├── Windows/
│ ├── Services/
│ └── Styles/
│
├── Game/
│ └── Scripts/
│ ├── Core/
│ ├── Gameplay/
│ ├── AI/
│ ├── UI/
│ ├── Online/
│ └── Utilities/
│
├── Scenes/
├── Prefabs/
├── Materials/
├── Audio/
└── Resources/

---

## 🛠️ HFDK (HiroForge Dev Kit)

HFDK is a custom Unity editor framework designed to accelerate development and automate workflows.

### Features

- Refactor Engine (code scanning and transformation)
- Custom editor UI system
- Modular architecture for tools
- AI-assisted development support

> ⚠️ All HFDK code runs inside `Assets/Editor/` and is not included in builds.

---

## 🔍 HF.RefactorEngine

Core system powering HFDK.

### Responsibilities

- Scan project files
- Analyze dependencies and structure
- Detect issues and improvements
- Generate refactor previews
- Execute safe transformations

### Architecture Layers

- **Domain** → Models (RefactorJob, History, etc.)
- **Application** → Orchestration logic
- **Infrastructure** → File system / IO
- **Analysis** → Dependency and symbol analysis
- **Scanning** → Project scanning pipeline
- **Preview** → Refactor previews

---

## 🎮 Game Architecture

The game lives in:
Assets/Game/

### Structure

- **Core** → Game loop and base systems
- **Gameplay** → Game mechanics
- **AI** → Logic and behaviors
- **UI** → Player interface
- **Online** → Multiplayer (planned)
- **Utilities** → Shared helpers

---

## 🤖 AI Workflow

This project is optimized for AI-assisted development.

### Tools

- Cursor (AI coding assistant)
- GitHub (version control)

### Workflow

1. Define a system
2. Generate code using AI
3. Validate in Unity
4. Refactor using HFDK
5. Commit changes

---

## 🚀 Getting Started

### Requirements

- Unity (latest LTS recommended)
- Git
- Cursor (optional)

### Setup
```bash
git clone https://github.com/Dirilu/HiroForgeProject.git

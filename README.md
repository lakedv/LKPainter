# LKPainter — Roadmap

This roadmap defines the planned evolution of the project from initial preparation to post-MVP growth.
It is aligned with the agreed project phases and will be updated as development progresses.

---

## Phase 0 — Documentation & Planning
**Status:** Complete

### Goals
- Consolidate all project documentation
- Define scope, architecture, and services clearly
- Establish a shared understanding for future contributors

### Deliverables
- README.md (normalized and unified)
- Roadmap.md
- Phase documentation (1–11)
- Clear microservice definitions

---

## Phase 1 — Backend Foundations
**Status:** Complete

### Goals
- Establish backend solution structure in ASP.NET Core
- Prepare SQL Server / Azure SQL integration
- Lay foundations for microservices

### Key Tasks
- Create solution and projects per microservice
- Configure Entity Framework Core
- Define base entities and DbContexts
- Implement basic health checks
- Configure authentication base (Identity / JWT)

---

## Phase 2 — Core Microservices Development (Current)
**Status:** In Progress

### Services
- UserService - Complete
- ProjectService - Pending
- ColorService - Pending
- CatalogService - Current

### Goals
- CRUD operations for core domain entities
- Stable API contracts
- Database migrations per service

---

## Phase 3 — SVG & Model Pipeline
**Status:** Planned

### Goals
- Define SVG structure standards
- Prepare initial Space Marine SVG models
- Validate layer-to-part mapping

### Key Tasks
- Segment reference images
- Convert to layered SVG
- Test compatibility with Konva.js

---

## Phase 4 — Frontend Core (React + Konva)
**Status:** Planned

### Goals
- Create base UI
- Implement painting canvas
- Load and manipulate SVG layers

### Key Features
- Color selection
- Part selection
- Real-time repainting
- Basic export (PNG)

---

## Phase 5 — Integration & User Projects
**Status:** Planned

### Goals
- Connect frontend with backend APIs
- Enable project persistence
- Display saved projects on Home

### Key Features
- Save / load projects
- User authentication flow
- Project gallery

---

## Phase 6 — MVP Stabilization
**Status:** Planned

### Goals
- Improve performance
- Fix critical bugs
- Polish UX

### Tasks
- Error handling improvements
- SVG optimization
- Performance testing

---

## Phase 7 — MVP Launch
**Status:** Planned

### Goals
- Deploy MVP
- Collect user feedback
- Monitor usage

### Deliverables
- Production deployment
- Basic analytics
- Public access to the tool

---

## Phase 8 — Post-MVP Expansion
**Status:** Future

### Possible Directions
- More Warhammer factions
- Custom 2D image painting
- Community sharing
- Advanced export options
- 3D painting exploration

---

## Notes
- This roadmap is intentionally flexible.
- Development will proceed iteratively.
- Scope adjustments will be documented before implementation.

---

_Last updated: Roadmap created before development start._

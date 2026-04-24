# 🏆 Competition Management API

A RESTful API system for managing sports competitions, teams, players, and coaches. Built with C# and designed to handle complex queries with grouping, ordering, and relational data.

---

## 📋 Description

The Competition Management API provides a backend system to organize and manage sports competitions. It supports full CRUD operations across coaches, competitions, players, and teams — with intelligent data grouping and aggregation endpoints.

---

## ✨ Features

- 🧑‍💼 **Coach Management** — View coaches with their team details, grouped by specialization
- 🏟️ **Competition Management** — Get competition info with applying teams and player counts; delete competitions
- 👟 **Player Management** — Update player positions; view all players grouped by team with youngest player highlighted
- 🏅 **Team Management** — Create teams; view all teams ordered by player count

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | C# |
| Framework | ASP.NET Core Web API |
| Architecture | RESTful API |

---

## 🔌 API Endpoints

### 👨‍💼 Coach Controller — `/api/coaches`

---

#### `GET /api/coaches`
**GetCoaches** — Get all coaches with their team name and team info, grouped by coach specialization.

**Response:**
```json
{
  "Fitness": [
    {
      "coachName": "Ahmed Ali",
      "specialization": "Fitness",
      "teamName": "Cairo Eagles",
      "teamCity": "Cairo"
    }
  ],
  "Tactics": [
    {
      "coachName": "Omar Hassan",
      "specialization": "Tactics",
      "teamName": "Alex Warriors",
      "teamCity": "Alexandria"
    }
  ]
}
```

---

#### `GET /api/coaches/{id}`
**GetSpecificCoach** — Get a specific coach with their team name, city, and number of players in their team.

**Response:**
```json
{
  "coachName": "Ahmed Ali",
  "specialization": "Fitness",
  "teamName": "Cairo Eagles",
  "teamCity": "Cairo",
  "numberOfPlayers": 15
}
```

---

### 🏟️ Competition Controller — `/api/competitions`

---

#### `GET /api/competitions/{id}`
**GetCompetitionInfo** — Get competition details including title, date, applying teams, and the number of players in each team — all grouped by competition location.

**Response:**
```json
{
  "Cairo": [
    {
      "title": "Spring Championship",
      "date": "2024-05-10",
      "teams": [
        { "teamName": "Cairo Eagles", "numberOfPlayers": 15 },
        { "teamName": "Giza Lions", "numberOfPlayers": 12 }
      ]
    }
  ]
}
```

---

#### `DELETE /api/competitions/{id}`
**DeleteCompetition** — Delete a competition by its ID.

**Response:**
```json
{
  "message": "Competition deleted successfully."
}
```

---

### 👟 Player Controller — `/api/players`

---

#### `PUT /api/players/{id}`
**UpdatePlayer** — Update only the position of a specific player.

**Request Body:**
```json
{
  "position": "Forward"
}
```

**Response:**
```json
{
  "message": "Player position updated successfully."
}
```

---

#### `GET /api/players`
**GetPlayers** — Get all players grouped by team name, with the youngest player in each team highlighted.

**Response:**
```json
{
  "Cairo Eagles": {
    "youngestPlayer": {
      "name": "Youssef Karim",
      "age": 18,
      "position": "Midfielder"
    },
    "players": [
      { "name": "Youssef Karim", "age": 18, "position": "Midfielder" },
      { "name": "Tarek Samir", "age": 22, "position": "Defender" }
    ]
  }
}
```

---

### 🏅 Team Controller — `/api/teams`

---

#### `POST /api/teams`
**CreateTeam** — Add a new team.

**Request Body:**
```json
{
  "teamName": "Delta Stars",
  "city": "Mansoura"
}
```

**Response:**
```json
{
  "message": "Team created successfully.",
  "teamId": 5
}
```

---

#### `GET /api/teams`
**GetTeams** — Get all teams with their player count, ordered descending by number of players.

**Response:**
```json
[
  { "teamName": "Cairo Eagles", "city": "Cairo", "numberOfPlayers": 20 },
  { "teamName": "Alex Warriors", "city": "Alexandria", "numberOfPlayers": 17 },
  { "teamName": "Giza Lions", "city": "Giza", "numberOfPlayers": 12 }
]
```

---

## 📊 Endpoint Summary

| Controller | Method | Endpoint | Description |
|------------|--------|----------|-------------|
| Coach | GET | `/api/coaches` | All coaches grouped by specialization |
| Coach | GET | `/api/coaches/{id}` | Specific coach with team info & player count |
| Competition | GET | `/api/competitions/{id}` | Competition info grouped by location |
| Competition | DELETE | `/api/competitions/{id}` | Delete a competition |
| Player | PUT | `/api/players/{id}` | Update player position |
| Player | GET | `/api/players` | All players grouped by team + youngest |
| Team | POST | `/api/teams` | Create a new team |
| Team | GET | `/api/teams` | All teams ordered by player count (desc) |

---

## 📂 Project Structure

```
CompetitionAPI/
├── Controllers/
│   ├── CoachController.cs
│   ├── CompetitionController.cs
│   ├── PlayerController.cs
│   └── TeamController.cs
├── Models/
│   ├── Coach.cs
│   ├── Competition.cs
│   ├── Player.cs
│   └── Team.cs
├── DTOs/
│   ├── CoachDto.cs
│   ├── CompetitionDto.cs
│   ├── PlayerDto.cs
│   └── TeamDto.cs
├── Services/
│   └── (business logic here)
├── Program.cs
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites

- .NET SDK 6.0 or higher
- Visual Studio / VS Code
- A configured database connection

### Run the Project

```bash
# Clone the repository
git clone https://github.com/Salah-Aldeen-Ibrahem/competition-api.git

# Navigate to project directory
cd competition-api

# Restore dependencies
dotnet restore

# Run the API
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`.

---

## 👨‍💻 Author

**Salah Aldeen Eid Khamis**
- GitHub: [@Salah-Aldeen-Ibrahem](https://github.com/Salah-Aldeen-Ibrahem)
- LinkedIn: [salah-aldeen-518b8131b](https://www.linkedin.com/in/salah-aldeen-518b8131b)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

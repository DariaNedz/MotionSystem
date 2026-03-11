# MotionSystem
# MotionSystem (A-Sys Motion)

MotionSystem is a mobile workout tracker built with .NET MAUI.  
The application helps track stretching and running sessions while visualizing physical progress through an XP, level, and rank system.

The main goal of the project is to support consistent training habits and provide a simple way to monitor long-term physical progress.

---

## Features

- Daily workout screen (Today)
- Exercise checklist
- Automatic XP calculation
- Partial workout completion
- Running distance tracking
- XP → Level → Rank progression system
- Save button to confirm workout completion
- Completed / missed day statistics
- Monthly calendar overview

---

## Application Structure

The application consists of three main screens.

### Today
Displays the current workout plan.

Functions:
- list of exercises
- completion checkboxes
- workout progress indicator
- rest timer between exercises
- save button to confirm the workout

### Profile
Displays the user's overall progress.

Includes:
- total accumulated XP
- current level
- current rank
- completed and missed workout statistics
- user avatar

### Calendar
Displays the monthly training overview.

Shows:
- running days
- stretching days
- rest days
- completed and missed workouts

---

## Rank System

User progress is based on accumulated XP.

| Rank | XP |
|-----|-----|
| Base | 0 – 199 |
| Stable | 200 – 399 |
| Consistent | 400 – 699 |
| Conditioned | 700 – 1099 |
| Controlled | 1100+ |

---

## Technologies

- .NET MAUI
- C#
- XAML
- Visual Studio 2022/2026

Target platforms:
- Android
- Windows

---

## Running the Project

1. Open the solution in **Visual Studio 2022/2026**
2. Make sure the **.NET MAUI workload** is installed
3. Select the target platform (Android or Windows)
4. Run the project using **Build → Run**

---

## Purpose of the Project

This project was created as a learning application demonstrating:

- cross-platform mobile development with .NET MAUI
- multi-screen application architecture
- implementation of a progress tracking system
- integration of XAML UI and C# logic

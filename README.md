Wafer Inspection Tool

Project Purpose
This project emulates a patterned wafer inspection system, similar to those used in semiconductor manufacturing. While real-world systems are vastly more complex—incorporating specialized hardware, precision calibration, image alignment, and advanced machine learning—this tool is a simplified simulation. It is intended for educational use, rapid prototyping, or architectural discussion.

Features
- Simulated image acquisition
- Mock preprocessing pipeline
- Rule-based defect detection engine
- Wafer map constraints (defect locations are validated against a die map)
- Realtime defect logging and display
- MVVM architecture (no code-behind logic)
- WPF UI with a DataGrid to show detected defects
- Start/Stop control for inspection simulation

Architecture Overview
This project follows a clean MVVM (Model-View-ViewModel) structure:
- Models: Core data types (e.g., `Defect`, `DefectType`)
- ViewModels: Implement `INotifyPropertyChanged`, expose data and commands (e.g., `RelayCommand`)
- Views: XAML UI (e.g., `MainWindow.xaml`) using data bindings
- Services: Simulate system components (e.g., `ImageAcquisitionService`, `DefectDetectionService`, etc.)

Getting Started
Requirements:
- .NET 6.0 or later
- Visual Studio 2022 or later (or compatible IDE)

Steps:
1. Clone this repository
2. Open the solution in Visual Studio
3. Build the solution
4. Run the project

Simulated Behavior
Every second, the tool simulates capturing an image, processes it, and applies rule-based inspection. If a defect is (randomly) detected, it is added to the DataGrid in the UI and logged to the console in real time. Use the Start/Stop buttons to control the simulation.

Motivation
This emulator was built to prototype and explore how a wafer inspection system might be architected in .NET/WPF using pure MVVM. It is designed for easy extension and as a foundation for more realistic simulations in the future.

Documentation
Project Architecture Diagram (PDF)

Sample Output Image (PNG)

Disclaimer
This is not a production or commercial tool. It does not connect to actual hardware or perform real defect classification. All data and behaviors are simulated for demonstration purposes only. 
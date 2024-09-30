using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alrazi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BehavioralProblems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehavioralProblems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigKey = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentStatus = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateNumber = table.Column<int>(type: "int", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeTimeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyStateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    AccessChannelId = table.Column<int>(type: "int", nullable: false),
                    AccessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    DiagnosisNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AccessChannels_AccessChannelId",
                        column: x => x.AccessChannelId,
                        principalTable: "AccessChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePermissions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Focus = table.Column<int>(type: "int", nullable: false),
                    IsQualified = table.Column<bool>(type: "bit", nullable: false),
                    RehabilitationSystem = table.Column<int>(type: "int", nullable: false),
                    ContinuousTraining = table.Column<bool>(type: "bit", nullable: false),
                    ReasonContinuousTraining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaknessRead = table.Column<bool>(type: "bit", nullable: false),
                    WeaknessWrite = table.Column<bool>(type: "bit", nullable: false),
                    WeaknessCalc = table.Column<bool>(type: "bit", nullable: false),
                    WeaknessSciences = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAbilities_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAcademics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LoveSchool = table.Column<bool>(type: "bit", nullable: false),
                    TopStudyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonFailure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplayInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovingSchoolInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAcademics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAcademics_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAutonomies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cleanliness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clothes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAutonomies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAutonomies_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDevelopments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Breastfeeding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teething = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChewingFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Walking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Immunity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstWords = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDevelopments_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEducationals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rehabilitation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RehabilitationAxes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEducationals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEducationals_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFamilyActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RelationshipParents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipSiblings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyVisits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WatchingTV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteractCelebrations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlingMoney = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFamilyActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFamilyActivities_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFamilyInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotherStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherAgeAtBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherAndMotherDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherAndMotherDiseases = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisabilityOfRelative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipWithDisabled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrotherAndSisterCount = table.Column<int>(type: "int", nullable: false),
                    ChildOrder = table.Column<int>(type: "int", nullable: false),
                    SeparatedParents = table.Column<bool>(type: "bit", nullable: true),
                    ChildResidence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFamilyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFamilyInfos_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Interests = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInterests_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLevelInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLevelInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLevelInfos_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentMedicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HeadInjury = table.Column<bool>(type: "bit", nullable: false),
                    SevereInfections = table.Column<bool>(type: "bit", nullable: false),
                    VaccineRelatedProblems = table.Column<bool>(type: "bit", nullable: false),
                    Tests = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMedicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMedicals_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentMedicalTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AudiogramType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudiogramTypeResult = table.Column<int>(type: "int", nullable: false),
                    EyeExamination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeExaminationResult = table.Column<int>(type: "int", nullable: false),
                    BrainScan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrainScanResult = table.Column<int>(type: "int", nullable: false),
                    LaboratoryTests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousMedications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentMedications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorDiagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMedicalTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMedicalTests_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentMistakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompareColleagues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BehavioralDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolDealing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnderstandingWellBehaved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssaultsOthers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelfReliant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClearExpression = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMistakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMistakes_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentMotherMedicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ComplicationsDuringPregnancy = table.Column<bool>(type: "bit", nullable: false),
                    MonthMotherExposedRadiation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TookMedicationWhilePregnant = table.Column<bool>(type: "bit", nullable: false),
                    PsychologicalState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PregnancyDuration = table.Column<int>(type: "int", nullable: false),
                    IsNatural = table.Column<bool>(type: "bit", nullable: false),
                    PlaceBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NurseryLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NurseryReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrowthComplete = table.Column<bool>(type: "bit", nullable: false),
                    GotJaundice = table.Column<bool>(type: "bit", nullable: false),
                    RhesusFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherProblem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMotherMedicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMotherMedicals_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstDiscoveryParents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescribeProblemAsSeenParents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeakingWay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyProblemsWithChild = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsRequiredChild = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentNotes_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPotentialEnhancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<bool>(type: "bit", nullable: false),
                    Activity = table.Column<bool>(type: "bit", nullable: false),
                    Materialism = table.Column<bool>(type: "bit", nullable: false),
                    Symbolism = table.Column<bool>(type: "bit", nullable: false),
                    Social = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPotentialEnhancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPotentialEnhancers_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPsychologyDevelopments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OutputOperations = table.Column<bool>(type: "bit", nullable: false),
                    SleepProblems = table.Column<bool>(type: "bit", nullable: false),
                    HyperActivity = table.Column<bool>(type: "bit", nullable: false),
                    Seizures = table.Column<bool>(type: "bit", nullable: false),
                    LanguageProblems = table.Column<bool>(type: "bit", nullable: false),
                    OtherProblems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EatProblems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPsychologyDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPsychologyDevelopments_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSiblings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSiblings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSiblings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSocialDevelopments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VisualCommunication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntentionalCommunication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacialExpressions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Play = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildRelationships = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseHelp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSocialDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSocialDevelopments_Students_Id",
                        column: x => x.Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentVisitCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentVisitCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentVisitCenters_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPsychologyDevelopmentBehavioralProblems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BehavioralProblemId = table.Column<int>(type: "int", nullable: false),
                    StudentPsychologyDevelopmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPsychologyDevelopmentBehavioralProblems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPsychologyDevelopmentBehavioralProblems_BehavioralProblems_BehavioralProblemId",
                        column: x => x.BehavioralProblemId,
                        principalTable: "BehavioralProblems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPsychologyDevelopmentBehavioralProblems_StudentPsychologyDevelopments_StudentPsychologyDevelopmentId",
                        column: x => x.StudentPsychologyDevelopmentId,
                        principalTable: "StudentPsychologyDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermissions_EmployeeId",
                table: "EmployeePermissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEducationals_StudentId",
                table: "StudentEducationals",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInterests_StudentId",
                table: "StudentInterests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLevelInfos_StudentId",
                table: "StudentLevelInfos",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPsychologyDevelopmentBehavioralProblems_BehavioralProblemId",
                table: "StudentPsychologyDevelopmentBehavioralProblems",
                column: "BehavioralProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPsychologyDevelopmentBehavioralProblems_StudentPsychologyDevelopmentId",
                table: "StudentPsychologyDevelopmentBehavioralProblems",
                column: "StudentPsychologyDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AccessChannelId",
                table: "Students",
                column: "AccessChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DiagnosisId",
                table: "Students",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalityId",
                table: "Students",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSiblings_StudentId",
                table: "StudentSiblings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentVisitCenters_StudentId",
                table: "StudentVisitCenters",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "EmployeePermissions");

            migrationBuilder.DropTable(
                name: "StudentAbilities");

            migrationBuilder.DropTable(
                name: "StudentAcademics");

            migrationBuilder.DropTable(
                name: "StudentAutonomies");

            migrationBuilder.DropTable(
                name: "StudentDevelopments");

            migrationBuilder.DropTable(
                name: "StudentEducationals");

            migrationBuilder.DropTable(
                name: "StudentFamilyActivities");

            migrationBuilder.DropTable(
                name: "StudentFamilyInfos");

            migrationBuilder.DropTable(
                name: "StudentInterests");

            migrationBuilder.DropTable(
                name: "StudentLevelInfos");

            migrationBuilder.DropTable(
                name: "StudentMedicals");

            migrationBuilder.DropTable(
                name: "StudentMedicalTests");

            migrationBuilder.DropTable(
                name: "StudentMistakes");

            migrationBuilder.DropTable(
                name: "StudentMotherMedicals");

            migrationBuilder.DropTable(
                name: "StudentNotes");

            migrationBuilder.DropTable(
                name: "StudentPotentialEnhancers");

            migrationBuilder.DropTable(
                name: "StudentPsychologyDevelopmentBehavioralProblems");

            migrationBuilder.DropTable(
                name: "StudentSiblings");

            migrationBuilder.DropTable(
                name: "StudentSocialDevelopments");

            migrationBuilder.DropTable(
                name: "StudentVisitCenters");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "BehavioralProblems");

            migrationBuilder.DropTable(
                name: "StudentPsychologyDevelopments");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AccessChannels");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}

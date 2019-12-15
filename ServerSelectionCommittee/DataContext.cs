using System.Data.Entity;


namespace ServerSelectionCommittee
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Enrollee")
        {  
        }

        public DbSet<BudgetOrCharge> BudgetOrCharges { get; set; }
        public DbSet<Concession> Concessions { get; set; }
        public DbSet<ContractEn> ContractEns { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Enrollee> Enrollees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FormStudy> FormStudies { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<LevelEducation> LevelEducations { get; set; }
        public DbSet<RelativeOrGuardian> RelativeOrGuardians { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<TrainingDirection> TrainingDirections { get; set; }
        public DbSet<TrainingPeriod> TrainingPeriods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

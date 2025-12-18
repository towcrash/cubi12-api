using System.Text.Json;
using Cubitwelve.Src.Models;

namespace Cubitwelve.Src.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CallEachSeeder(context, options);
        }

        public static void CallEachSeeder(DataContext context, JsonSerializerOptions options)
        {
            SeedFirstOrderTables(context, options);
            SeedSecondtOrderTables(context, options);
        }

        private static void SeedFirstOrderTables(DataContext context, JsonSerializerOptions options)
        {
            SeedRoles(context, options);
            SeedSubjects(context, options);
            SeedCareers(context, options);
            SeedSubjectResources(context, options);
            SeedResources(context, options);
        }

        private static void SeedSecondtOrderTables(DataContext context, JsonSerializerOptions options)
        {
            SeedSubjectsRelationships(context, options);
        }

        // --- AQUI ESTAN LOS CAMBIOS IMPORTANTES (Src -> src) ---

        private static void SeedRoles(DataContext context, JsonSerializerOptions options)
        {
            if (context.Roles.Any()) return;

            // CAMBIO: Src -> src
            var path = "src/Data/DataSeeders/RolesData.json"; 
            
            if (!File.Exists(path)) path = "Src/Data/DataSeeders/RolesData.json"; // Intento de fallback

            var rolesData = File.ReadAllText(path);
            var rolesList = JsonSerializer.Deserialize<List<Role>>(rolesData, options) ??
                throw new Exception("RolesData.json is empty");

            rolesList.ForEach(r => r.Name = r.Name.ToLower()); // Normalizar

            context.Roles.AddRange(rolesList);
            context.SaveChanges();
        }

        private static void SeedSubjects(DataContext context, JsonSerializerOptions options)
        {
            if (context.Subjects.Any()) return;

            // CAMBIO: Src -> src
            var path = "src/Data/DataSeeders/SubjectsData.json";
            
            if (!File.Exists(path)) path = "Src/Data/DataSeeders/SubjectsData.json";

            var subjectsData = File.ReadAllText(path);
            var subjectsList = JsonSerializer.Deserialize<List<Subject>>(subjectsData, options) ??
                throw new Exception("SubjectsData.json is empty");
            
            subjectsList.ForEach(s =>
            {
                s.Code = s.Code.ToLower();
                s.Name = s.Name.ToLower();
                s.Department = s.Department.ToLower();
            });

            context.Subjects.AddRange(subjectsList);
            context.SaveChanges();
        }

        private static void SeedCareers(DataContext context, JsonSerializerOptions options)
        {
            if (context.Careers.Any()) return;
            
            // CAMBIO: Src -> src
            var path = "src/Data/DataSeeders/CareersData.json";
            
            if (!File.Exists(path)) path = "Src/Data/DataSeeders/CareersData.json";

            var careersData = File.ReadAllText(path);
            var careersList = JsonSerializer.Deserialize<List<Career>>(careersData, options) ??
                throw new Exception("CareersData.json is empty");
            
            careersList.ForEach(s => s.Name = s.Name.ToLower());

            context.Careers.AddRange(careersList);
            context.SaveChanges();
        }

        private static void SeedSubjectsRelationships(DataContext context, JsonSerializerOptions options)
        {
            if (context.SubjectsRelationships.Any()) return;
            
            // CAMBIO: Src -> src
            var path = "src/Data/DataSeeders/SubjectsRelationsData.json";
            
            if (!File.Exists(path)) path = "Src/Data/DataSeeders/SubjectsRelationsData.json";

            var subjectsRelationshipsData = File.ReadAllText(path);
            var subjectsRelationshipsList = JsonSerializer
                .Deserialize<List<SubjectRelationship>>(subjectsRelationshipsData, options) ??
                throw new Exception("SubjectsRelationsData.json is empty");
            
            subjectsRelationshipsList.ForEach(s =>
            {
                s.SubjectCode = s.SubjectCode.ToLower();
                s.PreSubjectCode = s.PreSubjectCode.ToLower();
            });

            context.SubjectsRelationships.AddRange(subjectsRelationshipsList);
            context.SaveChanges();
        }

        private static void SeedSubjectResources(DataContext context, JsonSerializerOptions options)
        {
            if (context.SubjectResources.Any()) return;
            
            // CAMBIO: Src -> src
            var path = "src/Data/DataSeeders/SubjectsResourcesData.json";
            
            if (!File.Exists(path)) path = "Src/Data/DataSeeders/SubjectsResourcesData.json";

            var subjectResourcesData = File.ReadAllText(path);
            var subjectResourcesList = JsonSerializer
                .Deserialize<List<SubjectResource>>(subjectResourcesData, options) ??
                throw new Exception("SubjectsResourcesData.json is empty");
            
            subjectResourcesList.ForEach(s =>
            {
                s.Name = s.Name.ToLower();
                s.Description = s.Description.ToLower();
            });

            context.SubjectResources.AddRange(subjectResourcesList);
            context.SaveChanges();
        }

        private static void SeedResources(DataContext context, JsonSerializerOptions options)
        {
            if (context.Resources.Any()) return;
            
            // CAMBIO: Src -> src
            var path = "src/Data/DataSeeders/ResourcesData.json";
            
            if (!File.Exists(path)) path = "Src/Data/DataSeeders/ResourcesData.json";

            var resourcesData = File.ReadAllText(path);
            var resourcesList = JsonSerializer
                .Deserialize<List<Resource>>(resourcesData, options) ??
                throw new Exception("ResourcesData.json is empty");
            
            resourcesList.ForEach(s => s.Type = s.Type.ToLower());

            context.Resources.AddRange(resourcesList);
            context.SaveChanges();
        }
    }
}
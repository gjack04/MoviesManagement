using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class Mapper
    {
        #region MapEntityToModel

        public EmployeeModel MapEntityToModel(Employee entity)
        {
            EmployeeModel model = new EmployeeModel()
            {
                Id = entity.EmployeeId,
                Name = entity.Name,
                Surname = entity.Surname,
                IsDeleted = entity.IsDeleted,
                employeeProjectionModels = entity.Activities?.ConvertAll(MapEntityToModel)                
            };

            return model;
        }

        public MovieModel MapEntityToModel(Movie entity)
        {
            MovieModel model = new MovieModel()
            {
                Id = entity.MovieId,
                Title = entity.Title,
                AgeLimitId = entity.AgeLimitId,
                AgeLimit = entity.AgeLimit?.Description,
                DurationMins = entity.DurationMins,
                ImdbId = entity.ImdbId,
                IsDeleted = entity.IsDeleted,
                Technologies = entity.Technologies?.ConvertAll(MapEntityToModel),
                Projections = entity.Projections?.ConvertAll(MapEntityToModel)
            };
            return model;
        }

        public MovieProjectionModel MapEntityToModel(Projection entity)
        {
            MovieProjectionModel model = new MovieProjectionModel()
            {
                Id = entity.ProjectionId,
                FreeBy = entity.FreeBy,
                Start = entity.Start,
                RoomId = entity.RoomId,
                IsDeleted = entity.IsDeleted,
                RoomName = entity.Room?.Name
            };
            return model;
        }

        public ItemModel MapEntityToModel(Technology entity)
        {
            ItemModel model = new ItemModel()
            {
                Id = entity.TechnologyId,
                Name = entity.Name,
                Description = entity.TechnologyType
            };
            return model;
        }

        public EmployeeProjectionModel MapEntityToModel(ProjectionActivity entity)
        {
            EmployeeProjectionModel model = new EmployeeProjectionModel()
            {
                ActivityRoleId = entity.ActivityRoleId,
                EmployeeId = entity.EmployeeId,
                ProjectionId = entity.ProjectionId,
                RoomName = entity.Projection.Room.Name,
                
                Start = entity.Projection.Start,
                Description = entity.ActivityRole.Description,
            };
            return model;
        }

        #endregion

        #region MapModelToEntity

        public Employee MapModelToEntity(EmployeeModel model)
        {
            Employee entity = new Employee()
            {
                EmployeeId = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                IsDeleted = model.IsDeleted,
                Activities = model.employeeProjectionModels?.ConvertAll(MapModelToEntity)
            };

            return entity;
        }
        
        public Technology MapModelToEntity(ItemModel model)
        {
            Technology entity = new Technology()
            {
                TechnologyId = model.Id,
                Name = model.Name,
                TechnologyType = model.Description,
                IsDeleted = model.IsDeleted
            };
            return entity;
        }

        public Projection MapModelToEntity(MovieProjectionModel model)
        {
            Projection entity = new Projection()
            {
                ProjectionId = model.Id,
                RoomId = model.RoomId,
                Start = model.Start,
                FreeBy = model.FreeBy,
                IsDeleted = model.IsDeleted,
            };
            return entity;
        }

        public Movie MapModelToEntity(MovieModel model)
        {
            Movie entity = new Movie()
            {
                MovieId = model.Id,
                Title = model.Title,
                ImdbId = model.ImdbId,
                AgeLimitId = model.AgeLimitId,
                DurationMins = model.DurationMins,
                IsDeleted = model.IsDeleted,
                Technologies = model.Technologies?.ConvertAll(MapModelToEntity),
                Projections = model.Projections?.ConvertAll(MapModelToEntity)
            };
            return entity;
        }

        public ProjectionActivity MapModelToEntity(EmployeeProjectionModel model)
        {
            ProjectionActivity entity = new ProjectionActivity()
            {
                EmployeeId = model.EmployeeId,
                ProjectionId = model.ProjectionId,
                ActivityRoleId= model.ActivityRoleId
            };
            return entity;
        }

        #endregion
    }
}

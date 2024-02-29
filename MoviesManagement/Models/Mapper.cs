using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class Mapper
    {
        #region MapEntityToModel

        public TechnologyModel MapEntityToModel(Technology entity)
        {
            TechnologyModel model = new TechnologyModel()
            {
                TechnologyId = entity.TechnologyId,
                IsDeleted = entity.IsDeleted,
                Name = entity.Name,
                TechnologyType = entity.TechnologyType,
                TechnologyRoom = entity?.Rooms.ConvertAll(MapEntityToModel)
            };
            return model;
        }

        public TechnologyRoomModel MapEntityToModel(Room entity)
        {
            TechnologyRoomModel model = new TechnologyRoomModel()
            {
                CleanTimeMins = entity.CleanTimeMins,
                IsDeleted = entity.IsDeleted,
                Name = entity.Name,
                RoomId = entity.RoomId
            };
            return model;
        }

        public ProjectionActivityModel MapModelToEntity(ProjectionActivity entity)
        {
            var model = new ProjectionActivityModel()
            {
                ActivityRoleId = entity.ActivityRoleId,
                EmployeeId = entity.EmployeeId,
                ProjectionId = entity.ProjectionId,
            };
            return model;
        }

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

        public ItemModel MapEntityToModel(AgeLimit entity)
        {
            ItemModel model = new ItemModel() { Id = entity.AgeLimitId, Name = entity.Description };
            return model;
        }

        public ItemModel MapEntityToModelItem(Technology entity)
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

        public ProjectionModel MapEntityToModelProjection(Projection entity)
        {
            ProjectionModel model = new ProjectionModel()
            {
                ProjectionId = entity.ProjectionId,
                MovieId = entity.MovieId,
                RoomId = entity.RoomId,
                IsDeleted = entity.IsDeleted,
                FreeBy = entity.FreeBy,
                Start = entity.Start,
                ProjectionsActivities = entity.Activities?.ConvertAll(MapEntityToModelActivity)
            };
            return model;
        }

        public ActivityProjectionModel MapEntityToModelActivity(ProjectionActivity entity)
        {
            ActivityProjectionModel model = new ActivityProjectionModel()
            {
                EmployeeId = entity.EmployeeId,
                ActivityRoleId = entity.ActivityRoleId,
                ProjectionId = entity.ProjectionId
            };
            return model;
        }

        public ActivityRoleModel MapEntityToModel(ActivityRole entity)
        {
            ActivityRoleModel model = new ActivityRoleModel()
            {
                Id = entity.ActivityRoleId,
                Description = entity.Description,
                IsDeleted = entity.IsDeleted,
                Activities = entity.Activities.ConvertAll(MapEntityToModelActivity)
            };
            return model;
        }

        #endregion

        #region MapModelToEntity


        public ProjectionActivity MapModelToEntity(ProjectionActivityModel model)
        {
            var entity = new ProjectionActivity()
            {
                ActivityRoleId = model.ActivityRoleId,
                EmployeeId = model.EmployeeId,
                ProjectionId = model.ProjectionId,
            };
            return entity;
        }

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

        public Technology MapModelToEntity(TechnologyModel model)
        {
            Technology entity = new Technology()
            {
                TechnologyId = model.TechnologyId,
                Name = model.Name,
                Rooms = model?.TechnologyRoom.ConvertAll(MapModelToEntity),
                IsDeleted = model.IsDeleted
            };
            return entity;
        }

        public Room MapModelToEntity(TechnologyRoomModel model)
        {
            Room entity = new Room()
            {
                CleanTimeMins = model.CleanTimeMins,
                IsDeleted = model.IsDeleted,
                Name = model.Name,
                RoomId = model.RoomId,
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
                ActivityRoleId = model.ActivityRoleId
            };
            return entity;
        }

        public ProjectionActivity MapModelToEntityActivity(ActivityProjectionModel model)
        {
            ProjectionActivity entity = new ProjectionActivity()
            {
                ActivityRoleId = model.ActivityRoleId,
                EmployeeId = model.EmployeeId,
                ProjectionId = model.ProjectionId,
            };
            return entity;
        }

        public Projection MapModelToEntityProjection(ProjectionModel model)
        {
            Projection entity = new Projection()
            {
                ProjectionId = model.ProjectionId,
                RoomId = model.RoomId,
                MovieId = model.MovieId,
                FreeBy = model.FreeBy,
                Start = model.Start,
                IsDeleted = model.IsDeleted,
                Activities = model.ProjectionsActivities?.ConvertAll(MapModelToEntityActivity)
            };
            return entity;
        }

        public ActivityRole MapModelToEntity(ActivityRoleModel model)
        {
            ActivityRole entity = new ActivityRole()
            {
                ActivityRoleId = model.Id,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                Activities = model.Activities.ConvertAll(MapModelToEntityActivity)
            };
            return entity;
        }
        #endregion
    }
}

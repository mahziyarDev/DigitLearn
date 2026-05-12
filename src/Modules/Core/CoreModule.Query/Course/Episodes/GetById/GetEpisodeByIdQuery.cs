using Common.Query;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Query.Course.Episodes.GetById;

public record GetEpisodeByIdQuery(Guid EpisodeId) : IBaseQuery<EpisodeDto?>;
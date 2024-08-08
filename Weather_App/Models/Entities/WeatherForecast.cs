﻿using Betort.Models.Entities.Shared.EntityBase;
using Microsoft.AspNetCore.Identity;

namespace Weather_App.Models.Entities
{
    public class WeatherForecast : EntityBase<long>
    {
        public string? AccountId { get; set; }
        public virtual IdentityUser? Account { get; set; }
        public long LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public long CurrentId { get; set; }
        public virtual Current? Current { get; set; }
        public long ConditionId { get; set; }
        public virtual Condition? Condition { get; set; }
        public virtual ICollection<ForecastDay>? ForecastDays { get; set; }
    }
}
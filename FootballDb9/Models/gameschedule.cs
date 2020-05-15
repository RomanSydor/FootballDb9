namespace FootballDb9.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class gameschedule
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public Nullable<int> stadium { get; set; }
        public Nullable<int> HomeTeam { get; set; }
        public Nullable<int> AwayTeam { get; set; }
        public string Score { get; set; }
    
        public virtual clubs clubs { get; set; }
        public virtual clubs clubs1 { get; set; }
        public virtual stadiums stadiums { get; set; }
    }
}

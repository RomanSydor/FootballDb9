namespace FootballDb9.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public Nullable<int> Club { get; set; }
    
        public virtual clubs clubs { get; set; }
    }
}

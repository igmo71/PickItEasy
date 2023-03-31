﻿namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public List<WhsOrderOutProductVm>? Products { get; set; }
    }    
}
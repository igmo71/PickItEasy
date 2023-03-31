﻿namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class WhsOrderOutDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }

        public required List<WhsOrderOutProductDto> Products { get; set; }
    }

    public class WhsOrderOutProductDto
    {
        public required Guid ProductId { get; set; }
        public required float Count { get; set; }
    }
}
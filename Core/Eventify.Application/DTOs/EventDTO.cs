using Eventify.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Application.DTOs
{
    public class EventDTO
    {
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public Location Location { get; set; }
    }
}

﻿using Eventify.Application.Abstractions.Services;
using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Eventify.Domain.Entities;
using Eventify.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Persistence.Services
{
    public class EventService : IEventService
    {
        private readonly EventifyDbContext _context;

        public EventService(EventifyDbContext context)
        {
            _context = context;
        }

        public async Task CreateEventAsync(CreateEventDTO createEventDTO)
        {
            if (createEventDTO is not null)
            {
                var newEvent = new Event()
                {
                    Title = createEventDTO.Title,
                    Date = createEventDTO.Date,
                    Location = createEventDTO.Location,
                    
                };

                await _context.Events.AddAsync(newEvent);
                await _context.SaveChangesAsync();
            }
            else
                throw new NullReferenceException();

            
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination)
        {
            return await _context.Events.AsNoTracking().Select(x=>new EventDTO()
            {
                Title=x.Title,
                Date = x.Date,
                Location = x.Location,
            }).Skip(pagination.PageCount*pagination.ItemCount).Take(pagination.ItemCount).ToListAsync();
        }
    }
}

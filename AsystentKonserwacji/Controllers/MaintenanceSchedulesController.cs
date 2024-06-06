﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using Microsoft.EntityFrameworkCore;

namespace AsystentKonserwacji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceSchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceSchedule>>> GetMaintenanceSchedules()
        {
            return await _context.MaintenanceSchedules.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceSchedule>> GetMaintenanceScheduleById(int id)
        {
            var maintenanceSchedule = await _context.MaintenanceSchedules.FindAsync(id);

            if (maintenanceSchedule == null)
            {
                return NotFound();
            }

            return maintenanceSchedule;
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceSchedule>> AddMaintenanceSchedule(MaintenanceSchedule maintenanceSchedule)
        {
            _context.MaintenanceSchedules.Add(maintenanceSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenanceScheduleById", new { id = maintenanceSchedule.Id }, maintenanceSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenanceSchedule(int id, MaintenanceSchedule maintenanceSchedule)
        {
            if (id != maintenanceSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(maintenanceSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceSchedule(int id)
        {
            var maintenanceSchedule = await _context.MaintenanceSchedules.FindAsync(id);
            if (maintenanceSchedule == null)
            {
                return NotFound();
            }

            _context.MaintenanceSchedules.Remove(maintenanceSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaintenanceScheduleExists(int id)
        {
            return _context.MaintenanceSchedules.Any(e => e.Id == id);
        }
    }
}
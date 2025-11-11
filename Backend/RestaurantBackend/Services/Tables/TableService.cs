using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;

namespace RestaurantBackend.Services.Tables
{
	public class TableService : ITableService
	{
		private readonly PosDbContext _dbContext;

		public TableService(PosDbContext dbContext) { _dbContext = dbContext; }

		public async Task<List<TableDto>> GetAllTables(
			bool showClosed, bool showByServer,
			int serverId)
		{
			var response = new List<TableDto>();
			var tables = await _dbContext.Tables.ToListAsync();

			if (!showClosed)
				tables = tables.Where(t => t.Status != TableStatus.Closed).ToList();

			if (showByServer)
				tables = tables.Where(t => t.ServerId == serverId).ToList();

			foreach (var table in tables)
			{
				response.Add(table.ToDto());
			}

			return response;
		}

		public async Task<TableDto> GetTableById(int id)
		{
			var table = await _dbContext.Tables.FirstOrDefaultAsync(t => t.Id == id);

			if (table is null) throw new NotFoundException<Table>(id);

			return table.ToDto();
		}

		public async Task<TableDto> OpenTable(
			TableDto table, int serverId)
		{

			Table newTable = new(serverId, table.TableNumber, table.Seats);

			_dbContext.Tables.Add(newTable);
			await _dbContext.SaveChangesAsync();

			return newTable.ToDto();
		}

		public async Task CloseTable(int id)
		{
			var table = await _dbContext.Tables.FirstOrDefaultAsync(t => t.Id == id);

			if (table is null) throw new NotFoundException<Table>(id);

			table.CloseTable();
			await _dbContext.SaveChangesAsync();
		}
	}
}
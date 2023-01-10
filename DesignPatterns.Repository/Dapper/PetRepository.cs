using Dapper;
using DesignPatterns.Dapper.Models;
using DesignPatterns.Repository.Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DesignPatterns.Dapper
{
    public class PetRepository : IPetRepository
    {
        private readonly IConfiguration _configuration;

        public PetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region  sync
        public int Add(Pet entity)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            sqlConnection.Open();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PetName", entity.PetName, dbType: DbType.String, direction: ParameterDirection.Input, 50);
            int v = sqlConnection.QuerySingleOrDefault<int>("sp_addpet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return v;
        }

        public int Delete(int id)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            sqlConnection.Open();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Petid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            int result = sqlConnection.QuerySingleOrDefault<int>("sp_deletePet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IReadOnlyList<Pet> GetAll()
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            sqlConnection.Open();
            var dynamicParameters = new DynamicParameters();
            var result = sqlConnection.Query<Pet>("sp_getAllPet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Pet GetById(int id)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            sqlConnection.Open();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Petid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            Pet result = sqlConnection.QuerySingleOrDefault<Pet>("sp_getByIdPet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Update(Pet entity)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            sqlConnection.Open();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Petid", entity.PetId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dynamicParameters.Add("@PetName", entity.PetName, dbType: DbType.String, direction: ParameterDirection.Input, 50);
            int result = sqlConnection.QuerySingleOrDefault<int>("sp_updatePet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        #endregion

        #region Async
        public async Task<int> AddAsync(Pet entity)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            await sqlConnection.OpenAsync();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@PetName", entity.PetName, dbType: DbType.String, direction: ParameterDirection.Input, 50);
            int v = await sqlConnection.QuerySingleOrDefaultAsync<int>("sp_addpet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return v;
        }


        public async Task<int> DeleteAsync(int id)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            await sqlConnection.OpenAsync();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Petid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            int result = await sqlConnection.QuerySingleOrDefaultAsync<int>("sp_deletePet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IReadOnlyList<Pet>> GetAllAsync()
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            await sqlConnection.OpenAsync();
            var dynamicParameters = new DynamicParameters();
            var result = await sqlConnection.QueryAsync<Pet>("sp_getAllPet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            await sqlConnection.OpenAsync();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Petid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            Pet result = await sqlConnection.QuerySingleOrDefaultAsync<Pet>("sp_getByIdPet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> UpdateAsync(Pet entity)
        {
            using var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConnectionDapper"));
            await sqlConnection.OpenAsync();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Petid", entity.PetId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dynamicParameters.Add("@PetName", entity.PetName, dbType: DbType.String, direction: ParameterDirection.Input, 50);
            int result = await sqlConnection.QuerySingleOrDefaultAsync<int>("sp_updatePet", dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        #endregion
    }
}

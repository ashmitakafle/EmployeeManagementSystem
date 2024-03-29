﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryLayer.DapperRepository
{
    public class ApplicationWriteDbConnection : IApplicationWriteDbConnection
    {
        private readonly ApplicationDbContext context;
        public ApplicationWriteDbConnection(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Connection.ExecuteAsync(sql, param, transaction);
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await context.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Connection.QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}

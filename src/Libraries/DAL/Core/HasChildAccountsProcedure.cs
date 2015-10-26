// ReSharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.Core;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Core.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "core.has_child_accounts(pg_arg0 bigint)" on the database.
    /// </summary>
    public class HasChildAccountsProcedure : DbAccess
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "core";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "has_child_accounts";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "pg_arg0" argument of the function "core.has_child_accounts".
        /// </summary>
        public long PgArg0 { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "core.has_child_accounts(pg_arg0 bigint)" on the database.
        /// </summary>
        public HasChildAccountsProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "core.has_child_accounts(pg_arg0 bigint)" on the database.
        /// </summary>
        /// <param name="pgArg0">Enter argument value for "pg_arg0" parameter of the function "core.has_child_accounts".</param>
        public HasChildAccountsProcedure(long pgArg0)
        {
            this.PgArg0 = pgArg0;
        }
        /// <summary>
        /// Prepares and executes the function "core.has_child_accounts".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public bool Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"HasChildAccountsProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM core.has_child_accounts(@PgArg0);";

            query = query.ReplaceWholeWord("@PgArg0", "@0::bigint");


            List<object> parameters = new List<object>();
            parameters.Add(this.PgArg0);

            return Factory.Scalar<bool>(this._Catalog, query, parameters.ToArray());
        }


    }
}
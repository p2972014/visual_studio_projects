// See https://aka.ms/new-console-template for more information
using ConsoleAppSQLOracle.Models;

Console.WriteLine("Hello, World!");

var q = new m_oracle_db_xe();
var q3 = q.MY_TABLE1s.ToArray();
var qqq = 0;
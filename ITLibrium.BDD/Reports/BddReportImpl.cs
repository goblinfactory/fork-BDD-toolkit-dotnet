﻿using System;
using System.Collections.Generic;
using ITLibrium.Bdd.Scenarios;

namespace ITLibrium.Bdd.Reports
{
    internal class BddReportImpl : IBddReport
    {
        public string Name { get; }
        
        private readonly List<IBddScenarioResult> _scenarioResults = new List<IBddScenarioResult>();
        public IEnumerable<IBddScenarioResult> ScenarioResults => _scenarioResults;

        public BddReportImpl(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void AddScenarioResult(IBddScenarioResult result)
        {
            _scenarioResults.Add(result);
        }
    }
}
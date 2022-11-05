﻿using Atomy.SDK.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace Atomy.Database.Data;

public class ProjectContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the project meta records.
    /// </summary>
    public DbSet<ProjectMetaRecord>? AtomyProjectMetas { get; set; }

    /// <summary>
    /// Gets or sets the projects.
    /// </summary>
    public DbSet<ProjectRecord>? AtomyProjects { get; set; }

    /// <summary>
    /// Gets or sets the steps.
    /// </summary>
    public DbSet<StepRecord>? AtomySteps { get; set; }

    /// <summary>
    /// Gets or sets the ports.
    /// </summary>
    public DbSet<PortRecord>? AtomyPorts { get; set; }

    /// <summary>
    /// Gets or sets the links.
    /// </summary>
    public DbSet<LinkRecord>? AtomyLinks { get; set; }
}

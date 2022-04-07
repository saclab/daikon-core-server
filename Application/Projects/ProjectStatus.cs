namespace Application.Projects
{
  public class ProjectStatus
  {
    private ProjectStatus(string value) { Value = value; }

    public string Value { get; private set; }

    public static ProjectStatus Active { get { return new ProjectStatus("Active"); } }
    public static ProjectStatus Terminated { get { return new ProjectStatus("Terminated"); } }
    public static ProjectStatus Complete { get { return new ProjectStatus("Complete"); } }

  }
}

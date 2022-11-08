namespace Application.Projects
{
  public class ProjectStage
  {
    private ProjectStage(string value) { Value = value; }

    public string Value { get; private set; }

    public static ProjectStage HA { get { return new ProjectStage("HA"); } }
    public static ProjectStage H2L { get { return new ProjectStage("H2L"); } }
    public static ProjectStage LO { get { return new ProjectStage("LO"); } }
    public static ProjectStage SP { get { return new ProjectStage("SP"); } }
    public static ProjectStage PC { get { return new ProjectStage("PC"); } }
    public static ProjectStage IND { get { return new ProjectStage("IND"); } }
    public static ProjectStage P1 { get { return new ProjectStage("P1"); } }
  }
}

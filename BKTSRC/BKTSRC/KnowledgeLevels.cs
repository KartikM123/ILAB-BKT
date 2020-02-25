using Systems;
using Systems.Collections;

namespace BKTSRC {
    public class KnowledgeLevels
    {
        public string userId;

        //Initialize Skills to be evaluated
        public Skill EnvComfort;
        public Skill IfCondition;
        public Skill LogicExpression;

        //Interaction History (optional usage)
        public IList <Exercise> InteractionHistory;

        //D: Init Main Code Flow
        //R: New SingletonObject
        public KnowledgeLevels(string iuserId, float pLoEnv, float pLoIf, float pLoLogic)
        {
            this.userId = iuserId;
            InteractionHistory = new List<Exercise>();

            this.EnvComfort = new Skill("EnvComfort", this.userId, pLoEnv);
            this.IfCondition = new Skill("IfCondition", this.userId, pLoIf);
            this.LogicExpression = new Skill("LogicExpression", this.userId, pLoLogic);
        }

        //D: Init test
        //R: new Object
        public KnowledgeLevels(float pLoEnv, float pLoIf, float pLoLogic)
		{
            this.userId = "test";


            this.EnvComfort = new Skill("EnvComfort", pLoEnv, new TestDataManager("test"));
            this.IfCondition = new Skill("IfCondition", pLoIf, new TestDataManager("test"));
            this.LogicExpression = new Skill("LogicExpression", pLoLogic, new TestDataManager("test"));
        }

        //D: Use PFA to estimate performance on Exercise (summative) based on Skills tested
        //R: 0-1 probability student will be able to complete exercise
        public float estimatePerformance(Exercise e)
        {
            float correctness = 0.f;
            float maxScore = 0.f;
            //calculate pct correct on each skill tested
            foreach (KeyValuePair<string, int> pair in e.SkillsTested)
            {
                float skillValue = 0.f;
                switch (pair.key)
                {
                    case
                        "EnvComfort":
                    skillValue = this.EnvComfort.getKnowledgeState();
                        break;
                    case
                        "IfCondition":
                    skillValue = this.IfCondition.getKnowledgeState();
                        break;
                    case
                        "LogicExpression":
                    skillValue = this.LogicExpression.getKnowledgeState();
                        break;
                }
                correctness += skillValue * pair.value;
                maxScore += pair.value;
            }

            return correctness / maxScore;
        }

        //D: estimate test score based on multiple exercises
        //R: 0-1 pct expected to recieve on test
        public float estimateTestScore(List<Exercise> exercises)
        {
            float sum = 0.f;
            foreach (Exercise e in exercises)
            {
                sum += estimatePerformance(e);
            }
            return (sum / exercises.Count);
        }

        //D: update skills based on execise
        //R: N/A
        public void updateSkill(Execise e)
        {
            foreach (KeyValuePair<string, int> pair in e.SkillsCorrect)
            {
                switch (pair.key)
                {
                    case
                        "EnvComfort":
                    this.EnvComfort.updateKnowledge(pair.value, e.SkillsTested[pair.key]);
                        break;
                    case
                        "IfCondition":
                    this.IfCondition.updateKnowledge(pair.value, e.SkillsTested[pair.key]);
                        break;
                    case
                        "LogicExpression":
                    this.LogicExpression.updateKnowledge(pair.value, e.SkillsTested[pair.key]);
                        break;
                }
            }
        }


    }
}
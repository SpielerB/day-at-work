using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.SelectableObject.Interactions;

namespace Assets.Scripts.Tasks
{
    public class InteractionTask : Task
    {
        public TaskInteraction interaction;

        protected override void BeginTask()
        {
            interaction.OnInteractionFinished += InteractionFinished;
        }

        private void InteractionFinished(object sender, EventArgs e)
        {
            Finish();
            interaction.OnInteractionStarted -= InteractionFinished;
        }
    }
}

﻿/* Copyright (c) Cloud Software Group, Inc. 
 * 
 * Redistribution and use in source and binary forms, 
 * with or without modification, are permitted provided 
 * that the following conditions are met: 
 * 
 * *   Redistributions of source code must retain the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer. 
 * *   Redistributions in binary form must reproduce the above 
 *     copyright notice, this list of conditions and the 
 *     following disclaimer in the documentation and/or other 
 *     materials provided with the distribution. 
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND 
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
 * MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR 
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
 * SUCH DAMAGE.
 */

using XenAPI;


namespace XenAdmin.Wizards.PatchingWizard.PlanActions
{
    public class ApplyPatchPlanAction : HostPlanAction
    {
        private readonly Pool_patch _patch;
        private readonly bool _hostNeedsEvacuated;

        public ApplyPatchPlanAction(Host host, Pool_patch patch, bool hostNeedsEvacuated)
            : base(host)
        {
            _patch = patch;
            _hostNeedsEvacuated = hostNeedsEvacuated;
        }

        protected override void RunWithSession(ref Session session)
        {
            var host = GetResolvedHost();

            // evacuate the host, if needed,  before applying the update
            if (_hostNeedsEvacuated)
                EvacuateHost(ref session);

            AddProgressStep(string.Format(Messages.UPDATES_WIZARD_APPLYING_UPDATE, _patch.Name(), host.Name()));
            XenRef<Task> task = Pool_patch.async_apply(session, _patch.opaque_ref, host.opaque_ref);
            PollTaskForResultAndDestroy(Connection, ref session, task);
        }
    }
}
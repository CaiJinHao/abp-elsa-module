(self.webpackChunkant_design_pro=self.webpackChunkant_design_pro||[]).push([[164],{69240:function(oe,C,e){"use strict";e.r(C);var d=e(13062),p=e(71230),D=e(87593),m=e(37636),te=e(49111),$=e(19650),de=e(18106),N=e(63413),_e=e(89032),A=e(15746),ce=e(58024),j=e(91894),ve=e(17462),B=e(76772),V=e(11849),O=e(39428),fe=e(71194),b=e(53172),Z=e(3182),Q=e(71153),X=e(60331),g=e(2824),ae=e(49684),Y=e(41180),G=e(90774),F=e(78338),s=e(51188),i=e(13975),o=e(145),h=e(99043),t=e(46298),y=e(30381),Ae=e.n(y),E=e(67294),je=e(81493),me=e(51615),Be=e(25377),be=e(84619),Ke=e(667),Ue=e(74754),l=e(85893),K=function(J){return(0,l.jsx)(je.ZP,{value:J,options:{minimap:{enabled:!1},readOnly:!0,automaticLayout:!0,scrollBeyondLastLine:!1},language:"json"})},ke=function(){var J,ne,se,ie,re=(0,me.k6)(),Ne=(0,me.UO)(),c=(0,Be.YB)(),T=(0,E.useRef)(),Ye=E.useState(),pe=(0,g.Z)(Ye,2),Pt=pe[0],Ge=pe[1],Fe=E.useState(),ge=(0,g.Z)(Fe,2),Je=ge[0],ze=ge[1],He=E.useState(),Ee=(0,g.Z)(He,2),n=Ee[0],Ve=Ee[1],Qe=E.useState(!1),De=(0,g.Z)(Qe,2),Xe=De[0],he=De[1],qe=E.useState(),ye=(0,g.Z)(qe,2),W=ye[0],et=ye[1],tt=E.useState(),Me=(0,g.Z)(tt,2),at=Me[0],nt=Me[1],st=E.useState([]),Pe=(0,g.Z)(st,2),it=Pe[0],rt=Pe[1],lt=(0,E.useState)(),Ie=(0,g.Z)(lt,2),q=Ie[0],ut=Ie[1],ot=(0,E.useState)([]),Oe=(0,g.Z)(ot,2),U=Oe[0],dt=Oe[1],_t=E.useState("logs"),we=(0,g.Z)(_t,2),x=we[0],ee=we[1],ct=E.useState(!1),Te=(0,g.Z)(ct,2),Re=Te[0],vt=Te[1],ft=(0,E.useState)(""),Se=(0,g.Z)(ft,2),z=Se[0],Ze=Se[1],mt=(0,E.useState)(),We=(0,g.Z)(mt,2),R=We[0],xe=We[1],pt=function(){var u,v,_=[{key:"general",label:c.formatMessage({id:"page.instance.general"}),children:(0,l.jsx)(h.vY,{dataSource:R,column:1,columns:[{title:c.formatMessage({id:"page.instance.activityId"}),dataIndex:"activityId",copyable:!0},{title:c.formatMessage({id:"page.definition.field.name"}),dataIndex:"name",copyable:!0},{title:c.formatMessage({id:"page.definition.field.displayName"}),dataIndex:"displayName",copyable:!0},{title:c.formatMessage({id:"page.instance.outcomes"}),dataIndex:"outcomes",renderText:function(r){return(r??[]).length==0?"-":(r??[]).map(function(M){return(0,l.jsx)(X.Z,{children:M},M)})}}]})},{key:"stateData",label:c.formatMessage({id:"page.instance.stateData"}),children:(0,l.jsx)("div",{className:"activity-data-render-container ",children:K(JSON.stringify((u=R==null?void 0:R.stateData)!==null&&u!==void 0?u:{},null,2))})},{key:"journalData",label:c.formatMessage({id:"page.instance.journalData"}),children:(0,l.jsx)("div",{className:"activity-data-render-container ",children:K(JSON.stringify((v=R==null?void 0:R.journalData)!==null&&v!==void 0?v:{},null,2))})}];return _},gt=function(){var a=(0,Z.Z)((0,O.Z)().mark(function u(v,_){var I,r,M,k;return(0,O.Z)().wrap(function(f){for(;;)switch(f.prev=f.next){case 0:return f.next=2,(0,Y.lE)(v,_);case 2:if(M=f.sent,M){f.next=6;break}return b.Z.error({title:"Error",content:"The workflow defintion does not exist.",onOk:function(){re.goBack()}}),f.abrupt("return");case 6:return et(M),f.next=9,(0,Ke.MI)((I=M.activities)!==null&&I!==void 0?I:[],(r=M.connections)!==null&&r!==void 0?r:[]);case 9:k=f.sent,nt(k);case 11:case"end":return f.stop()}},u)}));return function(v,_){return a.apply(this,arguments)}}(),Et=function(){var a=(0,Z.Z)((0,O.Z)().mark(function u(v){var _,I;return(0,O.Z)().wrap(function(M){for(;;)switch(M.prev=M.next){case 0:return M.next=2,(0,G.jP)(v);case 2:I=M.sent,rt((_=I==null?void 0:I.items)!==null&&_!==void 0?_:[]);case 4:case"end":return M.stop()}},u)}));return function(v){return a.apply(this,arguments)}}(),Dt=function(){var a=(0,Z.Z)((0,O.Z)().mark(function u(v){var _;return(0,O.Z)().wrap(function(r){for(;;)switch(r.prev=r.next){case 0:return r.next=2,(0,G.Cb)(v);case 2:_=r.sent,ut(_);case 4:case"end":return r.stop()}},u)}));return function(v){return a.apply(this,arguments)}}(),ht=function(){var a=(0,Z.Z)((0,O.Z)().mark(function u(v){var _;return(0,O.Z)().wrap(function(r){for(;;)switch(r.prev=r.next){case 0:return he(!0),r.next=3,(0,G.mV)(v);case 3:if(_=r.sent,!_){r.next=9;break}Ve(_),ze(_==null?void 0:_.name),r.next=11;break;case 9:return b.Z.error({title:"Error",content:"The workflow instance does not exist.",onOk:function(){re.goBack()}}),r.abrupt("return");case 11:return r.next=13,Et(v);case 13:return r.next=15,Dt(v);case 15:return r.next=17,gt(_.workflowDefinitionId,_.version);case 17:he(!1);case 18:case"end":return r.stop()}},u)}));return function(v){return a.apply(this,arguments)}}();(0,E.useEffect)(function(){if(z){var a=U==null?void 0:U.find(function(u){return u.activityId==z});a?(xe(a??void 0),ee("activityState")):ee("logs")}},[z]);var yt=function(){var a=(0,Z.Z)((0,O.Z)().mark(function u(){var v,_,I,r;return(0,O.Z)().wrap(function(k){for(;;)switch(k.prev=k.next){case 0:I=((v=q==null?void 0:q.activities)!==null&&v!==void 0?v:[]).map(function(P){var f,S,L,w=W==null||(f=W.activities)===null||f===void 0?void 0:f.find(function(H){return H.activityId==P.activityId});return(0,V.Z)((0,V.Z)({},P),{},{name:(S=w==null?void 0:w.name)!==null&&S!==void 0?S:"",displayName:(L=w==null?void 0:w.displayName)!==null&&L!==void 0?L:""})}),dt(I),I.forEach(function(P){var f;if(P.isFaulted){var S;(S=T.current)===null||S===void 0||S.setNodeStatus(P.activityId,"failed")}else if(P.isExecuted){var L;(L=T.current)===null||L===void 0||L.setNodeStatus(P.activityId,"success")}else if(P.isExecuting){var w;(w=T.current)===null||w===void 0||w.setNodeStatus(P.activityId,"running")}if(((f=P.outcomes)!==null&&f!==void 0?f:[]).length>0){var H;((H=P.outcomes)!==null&&H!==void 0?H:[]).forEach(function(Le){var le,Mt=W==null||(le=W.connections)===null||le===void 0?void 0:le.find(function(Ce){return Ce.outcome==Le&&Ce.sourceId==P.activityId});if(Mt){var ue;(ue=T.current)===null||ue===void 0||ue.setNodeOutgoingEdgeStyle(P.activityId,Le,"success")}})}}),n!=null&&n.blockingActivities&&n.blockingActivities.forEach(function(P){var f;(f=T.current)===null||f===void 0||f.setNodeStatus(P.activityId,"running")}),n!=null&&(_=n.fault)!==null&&_!==void 0&&_.faultedActivityId&&((r=T.current)===null||r===void 0||r.setNodeStatus(n.fault.faultedActivityId,"failed"));case 5:case"end":return k.stop()}},u)}));return function(){return a.apply(this,arguments)}}();return(0,E.useEffect)(function(){if(Re&&n){var a,u;(a=T.current)===null||a===void 0||a.setAllNodeStatus("inactive"),(u=T.current)===null||u===void 0||u.setAllEdgesStyle("inactive"),yt()}},[Re,n,W,it,q]),(0,E.useEffect)(function(){var a,u=(a=Ne.id)!==null&&a!==void 0?a:"";if(!u){re.goBack();return}Ge(u),ht(u)},[0]),(0,l.jsxs)(t.ZP,{title:Je,loading:Xe,children:[(n==null?void 0:n.fault)&&(0,l.jsx)(B.Z,{showIcon:!0,message:n==null?void 0:n.fault.message,type:"error",description:"",style:{marginBottom:10}}),(0,l.jsx)(o.Z,{title:c.formatMessage({id:"page.instance.general"}),style:{marginBottom:16},children:(0,l.jsx)(h.vY,{dataSource:n,columns:[{title:c.formatMessage({id:"page.instance.field.name"}),dataIndex:"name",copyable:!0},{title:c.formatMessage({id:"page.instance.field.correlationId"}),dataIndex:"correlationId",copyable:!0},{title:c.formatMessage({id:"page.instance.field.version"}),dataIndex:"version",copyable:!0},{title:c.formatMessage({id:"page.instance.field.workflowStatus"}),dataIndex:"workflowStatus",valueEnum:Ue.J},{title:c.formatMessage({id:"common.dict.creationTime"}),dataIndex:"creationTime",valueType:"dateTime"},{title:c.formatMessage({id:"page.instance.field.finishedTime"}),dataIndex:"finishedTime",valueType:"dateTime"},{title:c.formatMessage({id:"page.instance.field.faultedTime"}),dataIndex:"faultedTime",valueType:"dateTime"},{title:c.formatMessage({id:"page.instance.field.lastExecutedTime"}),dataIndex:"lastExecutedTime",valueType:"dateTime"}]})}),(0,l.jsxs)(p.Z,{gutter:16,children:[(0,l.jsx)(A.Z,{span:14,children:(0,l.jsx)(j.Z,{title:c.formatMessage({id:"page.instance.graph"}),children:(0,l.jsx)(be.Z,{readonly:!0,actionRef:T,showMiniMap:!1,showNodeTypes:!1,showToolbar:!1,graphData:at,onDataUpdate:function(){vt(!0)},onNodeClick:function(u,v){Ze(v.id)},onBlankClick:function(){xe(void 0),Ze(""),ee("logs")}})})}),(0,l.jsx)(A.Z,{span:10,children:(0,l.jsxs)(j.Z,{title:"",activeTabKey:x,tabList:[{key:"activityState",tab:c.formatMessage({id:"page.instance.activityState"})},{key:"logs",tab:c.formatMessage({id:"page.instance.timeline"})},{key:"input",tab:c.formatMessage({id:"page.instance.input"})},{key:"fault",tab:c.formatMessage({id:"page.instance.exception"})},{key:"variables",tab:c.formatMessage({id:"page.instance.variables"})}],onTabChange:function(u){ee(u)},children:[x=="activityState"&&(0,l.jsxs)("div",{children:[!z&&(0,l.jsx)(B.Z,{message:c.formatMessage({id:"page.instance.node.select.tips"}),showIcon:!0}),z&&R&&(0,l.jsx)(N.Z,{items:pt()})]}),x==="logs"&&(0,l.jsx)(m.Z,{mode:"left",pending:(n==null?void 0:n.workflowStatus)==ae.x8.Running||(n==null?void 0:n.workflowStatus)==ae.x8.Suspended,reverse:!0,children:(U??[]).map(function(a){return(0,l.jsxs)(m.Z.Item,{color:a.isExecuting?"gray":a.isFaulted?"red":"green",dot:a.isExecuting?(0,l.jsx)(F.Z,{style:{fontSize:"12px"}}):null,children:[(0,l.jsxs)($.Z,{children:[(0,l.jsx)("span",{style:{fontSize:16},children:a.displayName}),(0,l.jsxs)(X.Z,{children:[(0,l.jsx)(s.Z,{})," ",Ae()(a.startTime).format("YYYY-MM-DD HH:mm:ss")]}),(0,l.jsxs)(X.Z,{children:[(0,l.jsx)(i.Z,{})," ",a.activityType]})]}),a.message&&(0,l.jsx)("p",{children:a.message})]},a.activityId)})}),x==="input"&&(0,l.jsx)("div",{className:"data-render-container",children:K(JSON.stringify((J=n==null?void 0:n.input)!==null&&J!==void 0?J:{},null,2))}),x==="fault"&&(0,l.jsx)("div",{className:"data-render-container",children:K(JSON.stringify((ne=n==null?void 0:n.fault)!==null&&ne!==void 0?ne:{},null,2))}),x==="variables"&&(0,l.jsx)("div",{className:"data-render-container",children:K(JSON.stringify((se=n==null?void 0:n.variables)!==null&&se!==void 0?se:{},null,2))}),x==="data"&&(0,l.jsx)("div",{className:"data-render-container",children:K(JSON.stringify((ie=n==null?void 0:n.activityData)!==null&&ie!==void 0?ie:{},null,2))})]})})]})]})};C.default=ke},74754:function(oe,C,e){"use strict";e.d(C,{J:function(){return te}});var d=e(32059),p=e(49684),D=e(25377),m,te=(m={},(0,d.Z)(m,p.x8.Idle,{text:(0,D.wv)({id:"page.instance.status.idle"}),status:"default"}),(0,d.Z)(m,p.x8.Running,{text:(0,D.wv)({id:"page.instance.status.running"}),status:"processing"}),(0,d.Z)(m,p.x8.Finished,{text:(0,D.wv)({id:"page.instance.status.finished"}),status:"success"}),(0,d.Z)(m,p.x8.Suspended,{text:(0,D.wv)({id:"page.instance.status.suspended"}),status:"warning"}),(0,d.Z)(m,p.x8.Faulted,{text:(0,D.wv)({id:"page.instance.status.faulted"}),status:"error"}),(0,d.Z)(m,p.x8.Cancelled,{text:(0,D.wv)({id:"page.instance.status.cancelled"}),status:"default"}),m)},90774:function(oe,C,e){"use strict";e.d(C,{BK:function(){return de},mV:function(){return _e},jP:function(){return ce},qd:function(){return ve},Cb:function(){return V},$5:function(){return fe},aT:function(){return Z},C4:function(){return G}});var d=e(39428),p=e(11849),D=e(3182),m=e(25377);function te(s,i){return $.apply(this,arguments)}function $(){return $=_asyncToGenerator(_regeneratorRuntime().mark(function s(i,o){return _regeneratorRuntime().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",request("/api/workflow-instances",_objectSpread({method:"DELETE",data:i,getResponse:!0},o||{})));case 1:case"end":return t.stop()}},s)})),$.apply(this,arguments)}function de(s,i){return N.apply(this,arguments)}function N(){return N=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances/".concat(i),(0,p.Z)({method:"DELETE",getResponse:!0},o||{})));case 1:case"end":return t.stop()}},s)})),N.apply(this,arguments)}function _e(s,i){return A.apply(this,arguments)}function A(){return A=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances/".concat(i),(0,p.Z)({method:"GET"},o||{})));case 1:case"end":return t.stop()}},s)})),A.apply(this,arguments)}function ce(s,i){return j.apply(this,arguments)}function j(){return j=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances/".concat(i,"/execution-logs"),(0,p.Z)({method:"GET"},o||{})));case 1:case"end":return t.stop()}},s)})),j.apply(this,arguments)}function ve(s,i){return B.apply(this,arguments)}function B(){return B=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances",(0,p.Z)({method:"GET",params:i},o||{})));case 1:case"end":return t.stop()}},s)})),B.apply(this,arguments)}function V(s,i){return O.apply(this,arguments)}function O(){return O=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances/".concat(i,"/execution-logs/summary"),(0,p.Z)({method:"GET"},o||{})));case 1:case"end":return t.stop()}},s)})),O.apply(this,arguments)}function fe(s,i){return b.apply(this,arguments)}function b(){return b=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances/statistics/count-date",(0,p.Z)({method:"GET",params:i},o||{})));case 1:case"end":return t.stop()}},s)})),b.apply(this,arguments)}function Z(s,i){return Q.apply(this,arguments)}function Q(){return Q=(0,D.Z)((0,d.Z)().mark(function s(i,o){return(0,d.Z)().wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.abrupt("return",(0,m.WY)("/api/workflow-instances/".concat(i,"/cancel"),(0,p.Z)({method:"POST",getResponse:!0},o||{})));case 1:case"end":return t.stop()}},s)})),Q.apply(this,arguments)}function X(s,i,o){return g.apply(this,arguments)}function g(){return g=_asyncToGenerator(_regeneratorRuntime().mark(function s(i,o,h){return _regeneratorRuntime().wrap(function(y){for(;;)switch(y.prev=y.next){case 0:return y.abrupt("return",request("/api/workflow-instances/".concat(i,"/dispatch"),_objectSpread({method:"POST",data:o,getResponse:!0},h||{})));case 1:case"end":return y.stop()}},s)})),g.apply(this,arguments)}function ae(s,i,o){return Y.apply(this,arguments)}function Y(){return Y=_asyncToGenerator(_regeneratorRuntime().mark(function s(i,o,h){return _regeneratorRuntime().wrap(function(y){for(;;)switch(y.prev=y.next){case 0:return y.abrupt("return",request("/api/workflow-instances/".concat(i,"/execute"),_objectSpread({method:"POST",data:o,getResponse:!0},h||{})));case 1:case"end":return y.stop()}},s)})),Y.apply(this,arguments)}function G(s,i,o){return F.apply(this,arguments)}function F(){return F=(0,D.Z)((0,d.Z)().mark(function s(i,o,h){return(0,d.Z)().wrap(function(y){for(;;)switch(y.prev=y.next){case 0:return y.abrupt("return",(0,m.WY)("/api/workflow-instances/".concat(i,"/retry"),(0,p.Z)({method:"POST",data:o,getResponse:!0},h||{})));case 1:case"end":return y.stop()}},s)})),F.apply(this,arguments)}}}]);

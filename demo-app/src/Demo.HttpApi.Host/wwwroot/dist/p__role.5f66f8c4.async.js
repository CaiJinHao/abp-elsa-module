(self.webpackChunkant_design_pro=self.webpackChunkant_design_pro||[]).push([[975],{52688:function(N,A,e){"use strict";var R=e(99653),w=e(97445),x=e(85893),j=e(67294),k=e(26227),I=["fieldProps","unCheckedChildren","checkedChildren","proFieldProps"],W=j.forwardRef(function(b,O){var F=b.fieldProps,B=b.unCheckedChildren,C=b.checkedChildren,$=b.proFieldProps,S=(0,w.Z)(b,I);return(0,x.jsx)(k.Z,(0,R.Z)({valueType:"switch",fieldProps:(0,R.Z)({unCheckedChildren:B,checkedChildren:C},F),ref:O,valuePropName:"checked",proFieldProps:$,filedConfig:{valuePropName:"checked",ignoreWidth:!0}},S))});A.Z=W},5966:function(N,A,e){"use strict";var R=e(99653),w=e(97445),x=e(85893),j=e(26227),k=["fieldProps","proFieldProps"],I=["fieldProps","proFieldProps"],W="text",b=function(C){var $=C.fieldProps,S=C.proFieldProps,D=(0,w.Z)(C,k);return(0,x.jsx)(j.Z,(0,R.Z)({valueType:W,fieldProps:$,filedConfig:{valueType:W},proFieldProps:S},D))},O=function(C){var $=C.fieldProps,S=C.proFieldProps,D=(0,w.Z)(C,I);return(0,x.jsx)(j.Z,(0,R.Z)({valueType:"password",fieldProps:$,proFieldProps:S,filedConfig:{valueType:W}},D))},F=b;F.Password=O,F.displayName="ProFormComponent",A.Z=F},1249:function(N,A,e){"use strict";e.r(A),e.d(A,{default:function(){return Ee}});var R=e(7359),w=e(687),x=e(13062),j=e(71230),k=e(89032),I=e(15746),W=e(63185),b=e(9676),O=e(11849),F=e(57663),B=e(71577),C=e(62350),$=e(24565),S=e(86582),D=e(2824),s=e(39428),v=e(34792),l=e(48086),t=e(3182),Z=e(25377);function u(T,h){return L.apply(this,arguments)}function L(){return L=(0,t.Z)((0,s.Z)().mark(function T(h,y){return(0,s.Z)().wrap(function(M){for(;;)switch(M.prev=M.next){case 0:return M.abrupt("return",(0,Z.WY)("/api/permission-management/permissions",(0,O.Z)({method:"GET",params:h},y||{})));case 1:case"end":return M.stop()}},T)})),L.apply(this,arguments)}function ce(T,h,y){return Y.apply(this,arguments)}function Y(){return Y=(0,t.Z)((0,s.Z)().mark(function T(h,y,a){return(0,s.Z)().wrap(function(g){for(;;)switch(g.prev=g.next){case 0:return g.abrupt("return",(0,Z.WY)("/api/permission-management/permissions",(0,O.Z)({method:"PUT",params:h,data:y,getResponse:!0},a||{})));case 1:case"end":return g.stop()}},T)})),Y.apply(this,arguments)}var U=e(86347),pe=e(46298),me=e(68129),X=e(37476),fe=e(5966),q=e(52688),ve=e(5894),_=e(67294),p=e(85893),he=function(){var T=(0,t.Z)((0,s.Z)().mark(function h(y){var a;return(0,s.Z)().wrap(function(g){for(;;)switch(g.prev=g.next){case 0:return g.next=2,(0,U.fA)(y);case 2:if(a=g.sent,!a){g.next=6;break}return l.ZP.success((0,Z.wv)({id:"common.dict.created.success"})),g.abrupt("return",!0);case 6:return g.abrupt("return",!1);case 7:case"end":return g.stop()}},h)}));return function(y){return T.apply(this,arguments)}}(),ge=function(){var T=(0,t.Z)((0,s.Z)().mark(function h(y,a){var M;return(0,s.Z)().wrap(function(m){for(;;)switch(m.prev=m.next){case 0:return m.next=2,(0,U.ul)(y,a);case 2:if(M=m.sent,!M){m.next=6;break}return l.ZP.success((0,Z.wv)({id:"common.dict.modified.success"})),m.abrupt("return",!0);case 6:return m.abrupt("return",!1);case 7:case"end":return m.stop()}},h)}));return function(y,a){return T.apply(this,arguments)}}(),Pe=function(){var T=(0,t.Z)((0,s.Z)().mark(function h(y){var a,M;return(0,s.Z)().wrap(function(m){for(;;)switch(m.prev=m.next){case 0:return m.next=2,(0,U.Rd)(y);case 2:if(M=m.sent,!(M!=null&&(a=M.response)!==null&&a!==void 0&&a.ok)){m.next=6;break}return l.ZP.success((0,Z.wv)({id:"common.dict.deleted.success"})),m.abrupt("return",!0);case 6:return m.abrupt("return",!1);case 7:case"end":return m.stop()}},h)}));return function(y){return T.apply(this,arguments)}}(),Ze=function(){var h,y=(0,_.useRef)(),a=(0,Z.YB)(),M=(0,_.useState)(!1),g=(0,D.Z)(M,2),m=g[0],G=g[1],ye=(0,_.useState)(""),ee=(0,D.Z)(ye,2),Me=ee[0],re=ee[1],Re=(0,_.useState)(),ae=(0,D.Z)(Re,2),K=ae[0],V=ae[1],be=(0,_.useState)(),ne=(0,D.Z)(be,2),se=ne[0],z=ne[1],Ce=(0,_.useState)(!1),te=(0,D.Z)(Ce,2),De=te[0],ie=te[1],we=(0,_.useState)(),le=(0,D.Z)(we,2),J=le[0],Te=le[1],je=(0,_.useState)([]),ue=(0,D.Z)(je,2),oe=ue[0],Se=ue[1],xe=function(){var f=(0,t.Z)((0,s.Z)().mark(function c(n){var o,d,i;return(0,s.Z)().wrap(function(r){for(;;)switch(r.prev=r.next){case 0:return d=(0,S.Z)(oe),d.forEach(function(E){E.isGranted=n.indexOf(E.name)>=0}),r.next=4,ce({providerKey:K.name,providerName:"R"},{permissions:d});case 4:if(i=r.sent,!(i!=null&&(o=i.response)!==null&&o!==void 0&&o.ok)){r.next=8;break}return l.ZP.success(a.formatMessage({id:"common.dict.modified.success"})),r.abrupt("return",!0);case 8:return r.abrupt("return",!1);case 9:case"end":return r.stop()}},c)}));return function(n){return f.apply(this,arguments)}}(),Oe=function(){var f=(0,t.Z)((0,s.Z)().mark(function c(n){var o,d,i,P;return(0,s.Z)().wrap(function(E){for(;;)switch(E.prev=E.next){case 0:return d=l.ZP.loading(a.formatMessage({id:"common.dict.loading"})),E.next=3,u({providerKey:n,providerName:"R"});case 3:i=E.sent,Te(i),P=((o=i==null?void 0:i.groups)!==null&&o!==void 0?o:[]).map(function(H){var Q;return((Q=H.permissions)!==null&&Q!==void 0?Q:[]).map(function(de){return{name:de.name,isGranted:de.isGranted}})}).flatMap(function(H){return H}),Se(P),d();case 8:case"end":return E.stop()}},c)}));return function(n){return f.apply(this,arguments)}}(),Fe=[{valueType:"index",title:"#",width:50},{dataIndex:"filter",title:a.formatMessage({id:"page.role.field.name"}),hideInTable:!0,hideInSetting:!0},{dataIndex:"name",title:a.formatMessage({id:"page.role.field.name"}),copyable:!0,hideInSearch:!0},{dataIndex:"isDefault",title:a.formatMessage({id:"page.role.field.isDefault"}),search:!1,align:"center",valueEnum:{true:{text:"Y"},false:{text:"N"}}},{dataIndex:"isPublic",title:a.formatMessage({id:"page.role.field.isPublic"}),search:!1,align:"center",valueEnum:{true:{text:"Y"},false:{text:"N"}}},{dataIndex:"isStatic",title:a.formatMessage({id:"page.role.field.isStatic"}),search:!1,align:"center",valueEnum:{true:{text:"Y"},false:{text:"N"}}},{title:a.formatMessage({id:"common.dict.table-action"}),valueType:"option",align:"center",width:160,render:function(c,n,o,d){return[!n.isStatic&&(0,p.jsx)("a",{onClick:function(){V(n),z(n.id),G(!0),re("".concat(a.formatMessage({id:"common.dict.edit"})," - ").concat(n.name))},children:a.formatMessage({id:"common.dict.edit"})},"edit"),(0,p.jsx)("a",{onClick:(0,t.Z)((0,s.Z)().mark(function i(){return(0,s.Z)().wrap(function(r){for(;;)switch(r.prev=r.next){case 0:return V(n),z(n.id),r.next=4,Oe(n.name);case 4:ie(!0);case 5:case"end":return r.stop()}},i)})),children:a.formatMessage({id:"page.role.permissions"})},"permission"),(0,p.jsx)($.Z,{title:a.formatMessage({id:"common.dict.delete.confirm"}),onConfirm:(0,t.Z)((0,s.Z)().mark(function i(){return(0,s.Z)().wrap(function(r){for(;;)switch(r.prev=r.next){case 0:return r.next=2,Pe(n.id);case 2:if(!r.sent){r.next=4;break}d==null||d.reload();case 4:case"end":return r.stop()}},i)})),children:(0,p.jsx)("a",{children:a.formatMessage({id:"common.dict.delete"})})},"delete")]}}];return(0,p.jsxs)(pe.ZP,{children:[(0,p.jsx)(me.Z,{columns:Fe,actionRef:y,rowKey:"id",toolBarRender:function(){return[(0,p.jsx)(B.Z,{type:"primary",onClick:function(){V(void 0),z(""),G(!0),re(a.formatMessage({id:"common.dict.create"}))},children:a.formatMessage({id:"common.dict.create"})},"add")]},request:function(){var f=(0,t.Z)((0,s.Z)().mark(function c(n){var o,d,i,P;return(0,s.Z)().wrap(function(E){for(;;)switch(E.prev=E.next){case 0:return o=n.current,d=n.pageSize,delete n.current,delete n.pageSize,i=(o-1)*d,E.next=6,(0,U.JV)((0,O.Z)((0,O.Z)({},n),{},{skipCount:i,maxResultCount:d}));case 6:if(P=E.sent,!P){E.next=11;break}return E.abrupt("return",{success:!0,data:P.items,total:P.totalCount});case 11:return E.abrupt("return",{success:!1});case 12:case"end":return E.stop()}},c)}));return function(c){return f.apply(this,arguments)}}()}),(0,p.jsxs)(X.Y,{title:Me,width:"600px",visible:m,modalProps:{destroyOnClose:!0,maskClosable:!1},preserve:!1,onVisibleChange:G,initialValues:K,onFinish:function(){var f=(0,t.Z)((0,s.Z)().mark(function c(n){var o,d,i;return(0,s.Z)().wrap(function(r){for(;;)switch(r.prev=r.next){case 0:if(o=!1,d=(0,O.Z)({},n),!se){r.next=8;break}return r.next=5,ge(se,d);case 5:o=r.sent,r.next=11;break;case 8:return r.next=10,he(d);case 10:o=r.sent;case 11:return o&&(G(!1),(i=y.current)===null||i===void 0||i.reload()),r.abrupt("return",o);case 13:case"end":return r.stop()}},c)}));return function(c){return f.apply(this,arguments)}}(),layout:"horizontal",labelCol:{span:4},children:[(0,p.jsx)(fe.Z,{rules:[{required:!0},{max:16}],name:"name",label:a.formatMessage({id:"page.role.field.name"})}),(0,p.jsx)(q.Z,{name:"isDefault",label:a.formatMessage({id:"page.role.field.isDefault"})}),(0,p.jsx)(q.Z,{name:"isPublic",label:a.formatMessage({id:"page.role.field.isPublic"})})]}),(0,p.jsx)(X.Y,{visible:De,onVisibleChange:ie,title:"".concat(a.formatMessage({id:"page.role.permissions"})," - ").concat(K==null?void 0:K.name),width:"600px",modalProps:{destroyOnClose:!0,maskClosable:!1},preserve:!1,initialValues:{name:oe.filter(function(f){return f.isGranted}).map(function(f){return f.name})},onFinish:function(){var f=(0,t.Z)((0,s.Z)().mark(function c(n){var o,d;return(0,s.Z)().wrap(function(P){for(;;)switch(P.prev=P.next){case 0:return d=(o=n.name)!==null&&o!==void 0?o:[],P.next=3,xe(d);case 3:return P.abrupt("return",P.sent);case 4:case"end":return P.stop()}},c)}));return function(c){return f.apply(this,arguments)}}(),children:(0,p.jsx)(ve.A.Item,{name:"name",children:(0,p.jsx)(b.Z.Group,{style:{width:"100%"},children:(0,p.jsx)(w.Z,{children:((h=J==null?void 0:J.groups)!==null&&h!==void 0?h:[]).map(function(f){var c;return(0,p.jsx)(w.Z.Panel,{header:f.displayName,children:(0,p.jsx)(j.Z,{children:((c=f.permissions)!==null&&c!==void 0?c:[]).map(function(n){return(0,p.jsx)(I.Z,{span:20,offset:n.parentName?1:0,children:(0,p.jsx)(b.Z,{style:{width:"100%"},value:n.name,checked:n.isGranted,children:n.displayName})},n.name)})})},f.name)})})})})})]})},Ee=Ze},86347:function(N,A,e){"use strict";e.d(A,{fA:function(){return k},Rd:function(){return W},JV:function(){return $},ul:function(){return D}});var R=e(39428),w=e(11849),x=e(3182),j=e(25377);function k(v,l){return I.apply(this,arguments)}function I(){return I=(0,x.Z)((0,R.Z)().mark(function v(l,t){return(0,R.Z)().wrap(function(u){for(;;)switch(u.prev=u.next){case 0:return u.abrupt("return",(0,j.WY)("/api/identity/roles",(0,w.Z)({method:"POST",data:l},t||{})));case 1:case"end":return u.stop()}},v)})),I.apply(this,arguments)}function W(v,l){return b.apply(this,arguments)}function b(){return b=(0,x.Z)((0,R.Z)().mark(function v(l,t){return(0,R.Z)().wrap(function(u){for(;;)switch(u.prev=u.next){case 0:return u.abrupt("return",(0,j.WY)("/api/identity/roles/".concat(l),(0,w.Z)({method:"DELETE",getResponse:!0},t||{})));case 1:case"end":return u.stop()}},v)})),b.apply(this,arguments)}function O(v){return F.apply(this,arguments)}function F(){return F=_asyncToGenerator(_regeneratorRuntime().mark(function v(l){return _regeneratorRuntime().wrap(function(Z){for(;;)switch(Z.prev=Z.next){case 0:return Z.abrupt("return",request("/api/identity/roles/all",_objectSpread({method:"GET"},l||{})));case 1:case"end":return Z.stop()}},v)})),F.apply(this,arguments)}function B(v,l){return C.apply(this,arguments)}function C(){return C=_asyncToGenerator(_regeneratorRuntime().mark(function v(l,t){return _regeneratorRuntime().wrap(function(u){for(;;)switch(u.prev=u.next){case 0:return u.abrupt("return",request("/api/identity/roles/".concat(l),_objectSpread({method:"GET"},t||{})));case 1:case"end":return u.stop()}},v)})),C.apply(this,arguments)}function $(v,l){return S.apply(this,arguments)}function S(){return S=(0,x.Z)((0,R.Z)().mark(function v(l,t){return(0,R.Z)().wrap(function(u){for(;;)switch(u.prev=u.next){case 0:return u.abrupt("return",(0,j.WY)("/api/identity/roles",(0,w.Z)({method:"GET",params:l},t||{})));case 1:case"end":return u.stop()}},v)})),S.apply(this,arguments)}function D(v,l,t){return s.apply(this,arguments)}function s(){return s=(0,x.Z)((0,R.Z)().mark(function v(l,t,Z){return(0,R.Z)().wrap(function(L){for(;;)switch(L.prev=L.next){case 0:return L.abrupt("return",(0,j.WY)("/api/identity/roles/".concat(l),(0,w.Z)({method:"PUT",data:t},Z||{})));case 1:case"end":return L.stop()}},v)})),s.apply(this,arguments)}}}]);

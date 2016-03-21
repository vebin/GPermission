import React, { Component } from 'react';
import { Tabs, Icon } from 'antd';
import AccountManager from './AccountManager';

const TabPane = Tabs.TabPane;

const tabContent = [
  <span><Icon type="user" />帐号管理</span>,
  <span><Icon type="setting" />系统设置</span>,
];

class RoleManager extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Tabs defaultActiveKey="1">
        <TabPane key="1" tab={tabContent[0]}>
          <AccountManager />
        </TabPane>
        <TabPane key="2" tab={tabContent[1]}>系统设置</TabPane>
      </Tabs>
    );
  }
}

export default RoleManager;

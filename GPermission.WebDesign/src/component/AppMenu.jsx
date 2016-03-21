import React, { Component } from 'react';
import { Menu, Icon } from 'antd';
import { Link } from 'react-router';
import './App.less';

const SubMenu = Menu.SubMenu;

class AppMenu extends Component {
  render() {
    return (
      <Menu onClick={this.handleClick}
        className="left-menu"
        defaultOpenKeys={['sub1']}
        selectedKeys={[this.props.selectedMenuKey]}
        mode="inline"
      >
        <SubMenu key="sub1" disabled title={ <span><Icon type="appstore" /><span>菜单</span></span> }>
          <Menu.Item key="/user-manager"><Link to="/user-manager">用户管理</Link></Menu.Item>
          <Menu.Item key="/role-manager"><Link to="/role-manager">角色管理</Link></Menu.Item>
          <Menu.Item key="/module-manager"><Link to="/module-manager">模块管理</Link></Menu.Item>
          <Menu.Item key="/authority-manager"><Link to="/authority-manager">权限管理</Link></Menu.Item>
          <Menu.Item key="/app-manager"><Link to="/app-manager">应用系统</Link></Menu.Item>
          <Menu.Item key="/system-setting"><Link to="/system-setting">系统设置</Link></Menu.Item>
        </SubMenu>
      </Menu>
    );
  }
}

AppMenu.propTypes = {
  selectedMenuKey: React.PropTypes.string,
};

export default AppMenu;

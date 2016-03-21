import React, { Component } from 'react';
import { Table, Button, Icon, Modal, message, Tree, Form, Input,
  Select, InputNumber, Switch } from 'antd';
import AppModalForm from '../component/AppModalForm';

const { Item: FormItem } = Form;
const { TreeNode } = Tree;
const confirm = Modal.confirm;

// 数据
const data = [{
  key: 1,
  systemId: 1,
  moduleCode: 1,
  name: '用户模块',
  type: 1,
  parentId: 0,
  location: '/user',
  assemblyName: 'User',
  assemblyFullName: 'BigUser',
  isLowLevel: true,
  validatedType: 1,
  isEnable: true,
  sort: 1,
  remark: '暂无备注',
  children: [{
    key: 11,
    systemId: 1,
    moduleCode: 1,
    name: '用户模块下级',
    type: 1,
    parentId: 0,
    location: '/user',
    assemblyName: 'User',
    assemblyFullName: 'BigUser',
    isLowLevel: true,
    validatedType: 1,
    isEnable: true,
    sort: 1,
    remark: '暂无备注',
  }],
}, {
  key: 2,
  systemId: 1,
  moduleCode: 1,
  name: '某某模块',
  type: 1,
  parentId: 0,
  location: '/user',
  assemblyName: 'User',
  assemblyFullName: 'BigUser',
  isLowLevel: true,
  validatedType: 1,
  isEnable: true,
  sort: 1,
  remark: '暂无备注',
}];

class ModuleManager extends Component {
  constructor(props) {
    super(props);

    this.state = {
      modalVisable: false,
      modalModalTitle: '',
      modalLoading: false,
      authorityModalVisable: false,
      authorityModalLoading: false,
    };

    this.handleCreate = this.handleCreate.bind(this);
    this.handleUpdate = this.handleUpdate.bind(this);
    this.handleAddSub = this.handleAddSub.bind(this);
    this.handleDelete = this.handleDelete.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
    this.renderAction = this.renderAction.bind(this);
    this.handleAuthorityUpdate = this.handleAuthorityUpdate.bind(this);
    this.handleAuthoritySubmit = this.handleAuthoritySubmit.bind(this);
    this.handleAuthorityCancel = this.handleAuthorityCancel.bind(this);
  }
  getColumns() {
    return [{
      title: '名称',
      dataIndex: 'name',
      key: 'name',
    }, {
      title: '连接地址',
      dataIndex: 'location',
      key: 'location',
    }, {
      title: '程序集名称',
      dataIndex: 'assemblyName',
      key: 'assemblyName',
    }, {
      title: '低级模块',
      dataIndex: 'isLowLevel',
      key: 'isLowLevel',
    }, {
      title: '类型',
      dataIndex: 'type',
      key: 'type',
    }, {
      title: '验证类型',
      dataIndex: 'validatedType',
      key: 'validatedType',
    }, {
      title: '备注',
      dataIndex: 'remark',
      key: 'remark',
    }, {
      title: '操作',
      key: 'operation',
      render: this.renderAction,
    }];
  }
  handleCreate() {
    this.setState({
      modalVisable: true,
      modalModalTitle: '添加模块',
    });
  }
  handleAddSub() {
    this.setState({
      modalVisable: true,
      modalModalTitle: '添加子模块',
    });
  }
  handleUpdate(row) {
    const me = this;
    return () => {
      me.props.form.setFieldsValue(row);
      me.setState({
        modalModalTitle: '编辑模块',
        modalVisable: true,
      });
    };
  }
  handleAuthorityUpdate() {
    const that = this;
    return () => {
      that.setState({
        authorityModalVisable: true,
      });
    };
  }
  handleCancel() {
    this.props.form.resetFields();
    this.setState({ modalVisable: false });
  }
  handleDelete() {
    confirm({
      title: '确认删除该权限？',
      onOk() {
        const hide = message.loading('正在执行中', 0);

        setTimeout(() => {
          hide();
          message.success('操作成功');
        }, 1000);
      },
    });
  }
  handleSubmit() {
    this.props.form.validateFields((errors, values) => {
      if (!!errors) {
        return;
      }
      console.log(values);
      this.setState({ modalLoading: true });
      setTimeout(() => {
        this.setState({
          modalLoading: false,
          modalVisable: false,
        });
        this.props.form.resetFields();
      }, 2000);
    });
  }
  handleAuthoritySubmit() {
    console.log(this);
  }
  handleAuthorityCancel() {
    this.setState({ authorityModalVisable: false });
  }

  renderAction(o, row) {
    return (
      <span>
        <Button className="mr-5" type="primary" onClick={this.handleAddSub}>
          <Icon type="plus" />添加子模块
        </Button>
        <Button className="mr-5" type="primary" onClick={this.handleUpdate(row)}>
          <Icon type="edit" />编辑
        </Button>
        <Button className="mr-5" type="primary" onClick={this.handleAuthorityUpdate(row)}>
          <Icon type="edit" />编辑权限
        </Button>
        <Button onClick={this.handleDelete}>
          <Icon type="delete" />删除
        </Button>
      </span>
    );
  }
  render() {
    const { getFieldProps } = this.props.form;
    const formItemLayout = {
      labelCol: { span: 6 },
      wrapperCol: { span: 14 },
    };

    return (
      <div>
        <Button className="mb-15" size="large" type="primary" onClick={this.handleCreate}>
          <Icon type="plus" />添加模块
        </Button>
        <Table
          columns={this.getColumns()}
          dataSource={data}
        />

        <AppModalForm
          modalVisable={this.state.modalVisable}
          modalModalTitle={this.state.modalModalTitle}
          modalLoading={this.state.modalLoading}
          handleSubmit={this.handleSubmit}
          handleCancel={this.handleCancel}
        >
          <Form horizontal onSubmit={this.handleSubmit}>
            <FormItem label="名称：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="name"
                placeholder="请输入名称"
                {...getFieldProps('name')}
              />
            </FormItem>
            <FormItem label="类型：" {...formItemLayout}>
              <Select
                name="type"
                defaultValue="1"
                style={{ width: 120 }}
                {...getFieldProps('type')}
              >
                <Select.Option value="1">Easy</Select.Option>
                <Select.Option value="2">Normal</Select.Option>
                <Select.Option value="3">Hard</Select.Option>
              </Select>
            </FormItem>
            <FormItem label="程序集名称：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="assemblyName"
                placeholder="请输入程序集名称"
                {...getFieldProps('assemblyName')}
              />
            </FormItem>
            <FormItem label="程序集全称：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="assemblyFullName"
                placeholder="请输入程序集全称"
                {...getFieldProps('assemblyFullName')}
              />
            </FormItem>
            <FormItem label="连接地址：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="location"
                placeholder="请输入连接地址"
                {...getFieldProps('location')}
              />
            </FormItem>
            <FormItem label="排序号：" {...formItemLayout} hasFeedback>
              <InputNumber
                min={1}
                name="sort"
                {...getFieldProps('sort')}
              />
            </FormItem>
            <FormItem label="是否可见：" {...formItemLayout} hasFeedback>
              <Switch
                name="isEnable"
                checkedChildren="开"
                unCheckedChildren="关"
                defaultChecked
                {...getFieldProps('isEnable')}
              />
            </FormItem>
            <FormItem label="备注：" {...formItemLayout}>
              <Input
                type="textarea"
                name="remark"
                placeholder="请输入备注"
                {...getFieldProps('remark')}
              />
            </FormItem>
          </Form>
        </AppModalForm>
        <AppModalForm
          modalVisable={this.state.authorityModalVisable}
          modalModalTitle="编辑权限"
          modalLoading={this.state.authorityModalLoading}
          handleSubmit={this.handleAuthoritySubmit}
          handleCancel={this.handleAuthorityCancel}
        >
          <Form horizontal onSubmit={this.handleAuthoritySubmit}>
            <FormItem>
              <Tree showLine multiple checkable>
                <TreeNode title="访问用户管理" key="0">
                  <TreeNode title="创建用户" key="0-0">
                    <TreeNode title="创建用户" key="0-0-1" />
                  </TreeNode>
                  <TreeNode title="删除用户" key="0-1" />
                  <TreeNode title="修改用户" key="0-2" />
                  <TreeNode title="查询用户" key="0-3" />
                </TreeNode>
                <TreeNode title="访问日志系统" key="1">
                  <TreeNode title="查询日志" key="1-0" />
                </TreeNode>
              </Tree>
            </FormItem>
          </Form>
        </AppModalForm>
      </div>
    );
  }
}

ModuleManager.propTypes = {
  form: React.PropTypes.object,
};

ModuleManager = Form.create()(ModuleManager);

export default ModuleManager;

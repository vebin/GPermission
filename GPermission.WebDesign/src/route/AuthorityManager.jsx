import React, { Component } from 'react';
import { Table, Button, Icon, Modal, message,
  Form, Input, Select, InputNumber, Switch } from 'antd';
import AppModalForm from '../component/AppModalForm';

const { Item: FormItem } = Form;
const confirm = Modal.confirm;

const data = [{
  key: 1,
  systemId: 1,
  name: '访问用户管理',
  type: '普通',
  parentId: 0,
  assemblyName: 'User',
  classIntro: 'User',
  location: '/user',
  sort: 1,
  state: 1,
  remark: '暂无备注',
  isEnable: true,
  children: [{
    key: 11,
    systemId: 1,
    name: '创建用户',
    type: '普通',
    parentId: 1,
    assemblyName: 'User',
    classIntro: 'User',
    location: '/user',
    sort: 1,
    state: 1,
    remark: '暂无备注',
    isEnable: true,
    children: [{
      key: 111,
      systemId: 1,
      name: '创建用户',
      type: '普通',
      parentId: 1,
      assemblyName: 'User',
      classIntro: 'User',
      location: '/user',
      sort: 1,
      state: 1,
      remark: '暂无备注',
      isEnable: true,
    }],
  }, {
    key: 12,
    systemId: 1,
    name: '删除用户',
    type: '普通',
    parentId: 1,
    assemblyName: 'User',
    classIntro: 'User',
    location: '/user',
    sort: 1,
    state: 1,
    remark: '暂无备注',
    isEnable: true,
  }, {
    key: 13,
    systemId: 1,
    name: '修改用户',
    type: '普通',
    parentId: 1,
    assemblyName: 'User',
    classIntro: 'User',
    location: '/user',
    sort: 1,
    state: 1,
    remark: '暂无备注',
    isEnable: true,
  }, {
    key: 14,
    systemId: 1,
    name: '查询用户',
    type: '普通',
    parentId: 1,
    assemblyName: 'User',
    classIntro: 'User',
    location: '/user',
    sort: 1,
    state: 1,
    remark: '暂无备注',
    isEnable: true,
  }],
}, {
  key: 2,
  systemId: 1,
  name: '访问日志系统',
  type: '普通',
  parentId: 0,
  assemblyName: 'Log',
  classIntro: 'Log',
  location: '/log',
  sort: 1,
  state: 1,
  remark: '暂无备注',
  isEnable: true,
  children: [{
    key: 21,
    systemId: 1,
    name: '查询日志',
    type: '普通',
    parentId: 1,
    assemblyName: 'Log',
    classIntro: 'Log',
    location: '/log',
    sort: 1,
    state: 1,
    remark: '暂无备注',
    isEnable: true,
  }],
}];

class AuthorityManager extends Component {
  constructor(props) {
    super(props);
    this.state = {
      modalVisable: false,
      modalModalTitle: '',
      modalLoading: false,
    };

    this.handleCreate = this.handleCreate.bind(this);
    this.handleUpdate = this.handleUpdate.bind(this);
    this.handleAddSub = this.handleAddSub.bind(this);
    this.handleDelete = this.handleDelete.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
    this.renderAction = this.renderAction.bind(this);
  }
  getColumns() {
    return [{
      title: '名称',
      dataIndex: 'name',
      key: 'name',
    }, {
      title: '权限地址',
      dataIndex: 'location',
      key: 'location',
    }, {
      title: '程序集名称',
      dataIndex: 'assemblyName',
      key: 'assemblyName',
    }, {
      title: '类名',
      dataIndex: 'classIntro',
      key: 'classIntro',
    }, {
      title: '类型',
      dataIndex: 'type',
      key: 'type',
    }, {
      title: '状态',
      dataIndex: 'state',
      key: 'state',
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
      modalModalTitle: '添加权限',
    });
  }
  handleAddSub() {
    this.setState({
      modalVisable: true,
      modalModalTitle: '添加子权限',
    });
  }
  handleUpdate(row) {
    const that = this;
    return () => {
      that.props.form.setFieldsValue(row);
      that.setState({
        modalModalTitle: '编辑权限',
        modalVisable: true,
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
  renderAction(o, row) {
    return (
      <span>
        <Button className="mr-5" type="primary" onClick={this.handleAddSub}>
          <Icon type="plus" />添加子权限
        </Button>
        <Button className="mr-5" type="primary" onClick={this.handleUpdate(row)}>
          <Icon type="edit" />编辑
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
        <Form inline>
          <Button className="mr-15" size="large" type="primary" onClick={this.handleCreate}>
            <Icon type="plus" />添加权限
          </Button>
          <FormItem label="所属应用系统：">
            <Select defaultValue="1" style={{ width: 120 }}>
              <Select.Option value="1">系统1</Select.Option>
              <Select.Option value="2">系统2</Select.Option>
              <Select.Option value="3">系统3</Select.Option>
            </Select>
          </FormItem>
        </Form>
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
                defaultValue="1"
                style={{ width: 120 }}
                name="type"
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
            <FormItem label="类名：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="classIntro"
                placeholder="请输入类名"
                {...getFieldProps('classIntro')}
              />
            </FormItem>
            <FormItem label="权限地址：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="location"
                placeholder="请输入权限地址"
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
            <FormItem label="是否启用：" {...formItemLayout} hasFeedback>
              <Switch
                name="isEnable"
                checkedChildren="开"
                unCheckedChildren="关"
                defaultChecked
                {...getFieldProps('isEnable')}
              />
            </FormItem>
          </Form>
        </AppModalForm>
      </div>
    );
  }
}

AuthorityManager.propTypes = {
  form: React.PropTypes.object,
};

AuthorityManager = Form.create()(AuthorityManager);

export default AuthorityManager;
